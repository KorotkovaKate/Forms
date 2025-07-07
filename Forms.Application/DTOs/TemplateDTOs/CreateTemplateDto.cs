using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Enums;

namespace Forms.Application.DTOs;

public class CreateTemplateDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ThemeType Theme { get; set; }
    public string? ImageUrl { get; set; }
    public List<string> Tags { get; set; } = [];
    public TemplateStatus Status { get; set; }
    public uint? TemplateCreatorId { get; set; }
    public List<QuestionDto> Questions { get; set; }
}