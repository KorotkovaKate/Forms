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
}