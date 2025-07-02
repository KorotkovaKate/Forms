using Forms.Core.Enums;
using Forms.Core.Models;

namespace Forms.Application.DTOs.QuestionDTOs;

public class QuestionDto
{
    public string Title { get; set; }
    public QuestionType Type { get; set; }
    public List<QuestionOptionDto>? Options { get; set; }
}