using Forms.Application.DTOs.AnswerDTOs;
using Forms.Core.Models;

namespace Forms.Application.DTOs.FormDTOs;

public class GetFormByTemplateIdDto
{
    public uint FormId { get; set; }
    public string UserName { get; set; }
    public DateTime PublishTime { get; set; }
    public string TemplateTitle {get;set;}
    public string? ImageUrl { get; set; }
    public List<QuestionsTitlesAndAnswersDto> QuestionsTitlesAndAnswers {get;set;}
}