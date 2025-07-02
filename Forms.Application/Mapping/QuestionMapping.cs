using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class QuestionMapping
{
    public static Question AddQuestion(QuestionDto questionDto)
    {
        return new Question
        {
            Title = questionDto.Title,
            Type = questionDto.Type,
            Options = questionDto.Options?.Select(option => new QuestionOption
            {
                Value = option.Value
            }).ToList()
        };
    }
}