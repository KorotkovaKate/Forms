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
}