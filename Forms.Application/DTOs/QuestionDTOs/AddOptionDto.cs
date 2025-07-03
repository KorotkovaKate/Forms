using Forms.Application.DTOs.AnswerDTOs;

namespace Forms.Application.DTOs.QuestionDTOs;

public class AddOptionDto
{
    public uint? QuestionId { get; set; }
    public string? Value { get; set; }
}