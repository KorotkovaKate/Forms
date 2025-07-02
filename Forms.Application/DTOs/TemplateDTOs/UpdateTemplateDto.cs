using Forms.Core.Enums;
using Forms.Core.Models;

namespace Forms.Application.DTOs;

public class UpdateTemplateDto
{
    public uint? TemplateId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ThemeType Theme { get; set; }
    public string? ImageUrl { get; set; }
    public List<string> Tags { get; set; }
    public TemplateStatus Status { get; set; }
}