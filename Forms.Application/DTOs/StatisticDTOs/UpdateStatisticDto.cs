using Forms.Core.Models;

namespace Forms.Application.DTOs;

public class UpdateStatisticDto
{
    public uint? StatisticId { get; set; }
    public uint? TemplateId { get; set; }
    public uint? QuestionId { get; set; }
}