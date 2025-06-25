using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public  class StatisticService(IStatisticRepository statisticRepository, IAnswerService answerService, IQuestionService questionService):IStatisticService
{
    public async Task AddStatistic(uint? questionId)
    {
        if (questionId == null)  {throw new ArgumentException("Incorrect questionId");}
        var answers = await answerService.GetAnswerByQuestionId(questionId.Value);
        if (answers == null) {throw new InvalidOperationException("No answers found");}
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
    }

    public async Task UpdateStatistic(UpdateStatisticDto updateStatisticDto)
    {
        if (updateStatisticDto.StatisticId == null)
        {
            throw new ArgumentException("Incorrect statisticId");
        }

        if (updateStatisticDto.Statistic == null)
        {
            throw new ArgumentNullException(nameof(updateStatisticDto.Statistic));
        }
        await statisticRepository.UpdateStatistic(updateStatisticDto.StatisticId.Value, updateStatisticDto.Statistic);
    }

    public async Task<List<Statistic>> GetStatisticsByTemplateId(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect templateId");}
        return await statisticRepository.GetStatisticsByTemplateId(templateId.Value);
    }
}