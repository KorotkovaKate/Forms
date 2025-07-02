using Forms.Application.DTOs.AnswerDTOs;

namespace Forms.Application.DTOs.FormDTOs;

public class CreateFormDto
{
    public uint? SubmitterId { get; set; }
    public uint? TemplateId { get; set; }
    public List<AnswerDto> Answers { get; set; }
}