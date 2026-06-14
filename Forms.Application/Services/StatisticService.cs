using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Forms.Application.Common.Mapping;
using Forms.Application.Common.Validators.StatisticValidators;
using Forms.Application.DTOs;
using Forms.Application.DTOs.StatisticDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Exceptions;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public  class StatisticService(IStatisticRepository statisticRepository, IAnswerService answerService, IQuestionService questionService): IStatisticService
{
    private const string FieldNullOrEmptyErrorMessage = "Field cannot be null or empty"; 
    
    public async Task<Result<bool>> AddStatistic(uint? questionId)
    {
        if(questionId == null)
            throw new ValidationException("questionId", FieldNullOrEmptyErrorMessage);
        
        var answersInResult = await answerService.GetAnswersByQuestionId(questionId.Value);
        if (!answersInResult.IsSuccess)
            return Result<bool>
                .Failure(answersInResult.ErrorMessage, HttpStatusCode.InternalServerError);
        
        if (answersInResult.Data.Count == 0) 
            return Result<bool>
                .Failure("Statistics can't be formed, because no answers", HttpStatusCode.BadRequest);

        var answers = answersInResult.Data;
        var grouped = answers
            .GroupBy(answer => answer.Value)
            .Select(group => new { Answer = group.Key, Count = group.Count() })
            .OrderByDescending(group => group.Count)
            .FirstOrDefault();

        if (grouped is null) {throw new InvalidOperationException("No answers found");}

        int percent = (int)Math.Round((double)(grouped.Count * 100) / answers.Count);

        var questionResult = await questionService.GetById(questionId.Value);
        if (!questionResult.IsSuccess) return Result<bool>.Failure(questionResult.ErrorMessage, HttpStatusCode.NotFound);
        
        var question = questionResult.Data;
        
        var statistic = new Statistic
        {
            QuestionId = questionId.Value,
            TemplateId = question.TemplateId,
            MostCommonAnswer = grouped.Answer,
            AnswerFrequencyInPercent = percent
        };

        await statisticRepository.AddStatistic(statistic);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> UpdateStatistic(UpdateStatisticDto? updateStatisticDto)
    {
        if (updateStatisticDto == null)
            throw new ValidationException("updateStatisticDto", FieldNullOrEmptyErrorMessage);
        
        var validator = new UpdateStatisticDtoValidator();
        var validationResult = await validator.ValidateAsync(updateStatisticDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.ToDictionary());
        
        var statistic = StatisticMapping.UpdateStatistic(updateStatisticDto);
        await statisticRepository.UpdateStatistic(statistic);
        return Result<bool>.Success(true);
    }

    public async Task<Result<List<GetStatisticDto>>> GetStatisticsByTemplateId(uint? templateId)
    {
        if(templateId == null)
            return Result<List<GetStatisticDto>>
                .Failure("Template Id can't be null", HttpStatusCode.BadRequest);
        
        var statisctic = await statisticRepository.GetStatisticsByTemplateId(templateId.Value);
        if(statisctic.Count == 0) 
            return Result<List<GetStatisticDto>>
                .Failure("No statistics found", HttpStatusCode.NotFound);
        
        var allStatistic = StatisticMapping.GetStatistic(statisctic);
        
        return Result<List<GetStatisticDto>>.Success(allStatistic);
    }

    public async Task<Result<bool>> RecalculateTemplateStatistics(uint templateId)
    {
        var existingStats = await statisticRepository.GetStatisticsByTemplateId(templateId);
        var statsDictionary = existingStats.ToDictionary(s => s.QuestionId);
        
        var questionsResult = await questionService.GetQuestionsByTemplateId(templateId);
        if (!questionsResult.IsSuccess)
            return Result<bool>.Failure(questionsResult.ErrorMessage, HttpStatusCode.NotFound);

        foreach (var question in questionsResult.Data)
        { 
            var answersInResult = await answerService.GetAnswersByQuestionId(question.Id); 
            if (!answersInResult.IsSuccess || answersInResult.Data.Count == 0) 
                continue;

            var answers = answersInResult.Data;
            
            var grouped = answers
                .GroupBy(a => a.Value)
                .Select(g => new { Answer = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .FirstOrDefault();

            if (grouped is null) continue;
            
            int percent = (int)Math.Round((double)(grouped.Count * 100) / answers.Count);
            
            if (statsDictionary.TryGetValue(question.Id, out var existingStat))
            {
                existingStat.MostCommonAnswer = grouped.Answer;
                existingStat.AnswerFrequencyInPercent = percent;
                
                await statisticRepository.UpdateStatistic(existingStat); 
            }
            else 
            {
                var newStatistic = new Statistic 
                { 
                    TemplateId = templateId, 
                    QuestionId = question.Id, 
                    MostCommonAnswer = grouped.Answer, 
                    AnswerFrequencyInPercent = percent 
                };
            
                await statisticRepository.AddStatistic(newStatistic);
            }
        }

        return Result<bool>.Success(true);
    }
}