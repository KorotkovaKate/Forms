using Forms.Core.Enums;

namespace Forms.Application.DTOs;

public class GetAllTemplatesDto
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public int CountOfLikes { get; set; }
    public TemplateStatus Status { get; set; }
}