using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class StatisticMapping
{
    public static Statistic UpdateStatistic(UpdateStatisticDto updateStatisticDto)
    {
        return new Statistic
        {
            Id = updateStatisticDto.StatisticId.Value,
            TemplateId = updateStatisticDto.TemplateId.Value,
            QuestionId = updateStatisticDto.QuestionId.Value,
        };
    }

    public static List<GetStatisticDto> GetStatistic(List<Statistic> statistics)
    {
        List<GetStatisticDto> allStatistic = [];
        foreach (var statistic in statistics)
        {
            var statisticDto = new GetStatisticDto
            {
                StatisticId = statistic.Id,
                MostCommonAnswer = statistic.MostCommonAnswer,
                AnswerFrequencyInPercent = statistic.AnswerFrequencyInPercent,
                TemplateTitle = statistic.Template.Title,
                ImageUrl = statistic.Template.ImageUrl,
                QuestionTitle = statistic.Question.Title,
            };
            allStatistic.Add(statisticDto);
        }
        return allStatistic;
    }
}