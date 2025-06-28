using Forms.Core.Models;

namespace Forms.Application.DTOs;

public class UpdateTemplateDto
{
    public uint? TemplateId { get; set; }
    public Template Template { get; set; }
}