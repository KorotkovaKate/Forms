using System.Net;
using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public  class StatisticService(IStatisticRepository statisticRepository, IAnswerService answerService, IQuestionService questionService):IStatisticService
{
    public async Task<Result<bool>> AddStatistic(uint? questionId)
    {
        if(questionId == null) Result<bool>.Failure("Incorrect question ID", HttpStatusCode.BadRequest);
        var answersInResult = await answerService.GetAnswersByQuestionId(questionId.Value);
        if (!answersInResult.IsSuccess)
            return Result<bool>.Failure(answersInResult.ErrorMessage, HttpStatusCode.InternalServerError); //can use my exception
        
        if (answersInResult.Data.Count == 0) 
            return Result<bool>.Failure("Statistics can't be formed, because no answers", HttpStatusCode.BadRequest);

        var answers = answersInResult.Data;
        var grouped = answers
            .GroupBy(answer => answer.Value)
            .Select(group => new { Answer = group.Key, Count = group.Count() })
            .OrderByDescending(group => group.Count)
            .FirstOrDefault();

        if (grouped is null) {throw new InvalidOperationException("No answers found");}

        int percent = (int)Math.Round((double)(grouped.Count * 100) / answers.Count);

        var question = await questionService.GetById(questionId.Value);
        if (question == null) {throw new InvalidOperationException("No question found");}
        
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

    public async Task UpdateStatistic(UpdateStatisticDto updateStatisticDto)
    {
        ArgumentNullException.ThrowIfNull(updateStatisticDto, "Update statistic Dto can't be null");
        ArgumentNullException.ThrowIfNull(updateStatisticDto.StatisticId, "Update statistic Id can't be null");
        ArgumentNullException.ThrowIfNull(updateStatisticDto.QuestionId, "QuestionId can't be null");
        ArgumentNullException.ThrowIfNull(updateStatisticDto.TemplateId, "TemplateId can't be null");
        var statistic = StatisticMapping.UpdateStatistic(updateStatisticDto);
        await statisticRepository.UpdateStatistic(statistic);
    }

    public async Task<List<GetStatisticDto>> GetStatisticsByTemplateId(uint? templateId)
    {
        ArgumentNullException.ThrowIfNull(templateId, "Template id can't be null");
        var statisctic = await statisticRepository.GetStatisticsByTemplateId(templateId.Value);
        if(!statisctic.Any()) throw new ArgumentException("No statistics found");
        var allStatistic = StatisticMapping.GetStatistic(statisctic);
        return allStatistic;
    }
}