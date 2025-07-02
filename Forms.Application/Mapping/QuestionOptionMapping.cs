using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class QuestionOptionMapping
{
    public static QuestionOption AddOption(QuestionOptionDto questionOptionDto)
    {
        return new QuestionOption
        {
            Value = questionOptionDto.Value
        };
    }
}