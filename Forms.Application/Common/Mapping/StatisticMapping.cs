using Forms.Application.DTOs;
using Forms.Application.DTOs.StatisticDTOs;
using Forms.Core.Models;

namespace Forms.Application.Common.Mapping;

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
                QuestionId = statistic.QuestionId,
                TemplateId = statistic.TemplateId,
                MostCommonAnswer = statistic.MostCommonAnswer,
                AnswerFrequencyInPercent = statistic.AnswerFrequencyInPercent,
            };
            allStatistic.Add(statisticDto);
        }
        return allStatistic;
    }
}