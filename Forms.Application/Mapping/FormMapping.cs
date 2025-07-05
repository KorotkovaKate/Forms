using Forms.Application.DTOs.AnswerDTOs;
using Forms.Application.DTOs.FormDTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class FormMapping
{
    public static Form CreateForm(CreateFormDto createFormDto)
    {
        return new Form
        {
            SubmitterId = createFormDto.SubmitterId.Value,
            TemplateId = createFormDto.TemplateId.Value,
            Answers = createFormDto.Answers.Select(answer => new Answer
            {
                Value = answer.Value,
            }).ToList()
        };
    }

    public static List<GetFormByTemplateIdDto> GetFormByTemplateId(List<Form> forms)
    {
        List<GetFormByTemplateIdDto> allForms = [];
        foreach (var form in forms)
        {
            var formDto = new GetFormByTemplateIdDto
            {
                FormId = form.Id,
                UserName = form.Submitter.UserName,
                PublishTime = form.SubmittedTime,
                TemplateTitle = form.Template.Title,
                ImageUrl = form.Template.ImageUrl,
                QuestionsTitlesAndAnswers = form.Answers.Select(answer => new QuestionsTitlesAndAnswersDto
                {
                    QuestionTitle = answer.Question.Title,
                    AnswerValue = answer.Value
                }).ToList()
            };
            allForms.Add(formDto);
        }
        return allForms;
    }
}