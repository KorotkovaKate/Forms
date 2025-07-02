using Forms.Application.DTOs.AnswerDTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class AnswerMapping
{
    public static Answer AddAnswer(AddAnswerDto addAnswerDto)
    {
        return new Answer
        {
            QuestionId = addAnswerDto.QuestionId.Value,
            Value = addAnswerDto.Value,
        };
    }
}