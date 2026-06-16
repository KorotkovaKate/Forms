using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Models;

namespace Forms.Application.Common.Mapping;

public class QuestionOptionMapping
{
    public static QuestionOption AddOption(AddOptionDto addOptionDto)
    {
        return new QuestionOption
        {
            QuestionId = addOptionDto.QuestionId.Value,
            Value = addOptionDto.Value
        };
    }
}