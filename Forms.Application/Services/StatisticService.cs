using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public  class StatisticService(IStatisticRepository statisticRepository, IAnswerService answerService, IQuestionService questionService):IStatisticService
{
    public async Task AddStatistic(uint? questionId)
    {
        ArgumentNullException.ThrowIfNull(questionId, "Question id can't be null");
        var answers = await answerService.GetAnswersByQuestionId(questionId.Value);
        if (!answers.Any()) {throw new InvalidOperationException("No answers found");}
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
        ArgumentNullException.ThrowIfNull(updateStatisticDto, "Update statistic Dto can't be null");
        ArgumentNullException.ThrowIfNull(updateStatisticDto.StatisticId, "Update statistic Id can't be null");
        ArgumentNullException.ThrowIfNull(updateStatisticDto.QuestionId, "QuestionId can't be null");
        ArgumentNullException.ThrowIfNull(updateStatisticDto.TemplateId, "TemplateId can't be null");
        var statistic = StatisticMapping.UpdateStatistic(updateStatisticDto);
        await statisticRepository.UpdateStatistic(statistic);
    }

    public async Task<List<Statistic>> GetStatisticsByTemplateId(uint? templateId)
    {
        ArgumentNullException.ThrowIfNull(templateId, "Template id can't be null");
        var statisctic = await statisticRepository.GetStatisticsByTemplateId(templateId.Value);
        if(!statisctic.Any()) throw new ArgumentException("No statistics found");
        return statisctic;
    }
}