using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class TemplateMapping
{
    public static Template UpdateTemplate(UpdateTemplateDto updateTemplateDto)
    {
        return new Template
        {
            Title = updateTemplateDto.Title,
            Description = updateTemplateDto.Description,
            Theme = updateTemplateDto.Theme,
            ImageUrl = updateTemplateDto.ImageUrl,
            Tags = updateTemplateDto.Tags,
            Status = updateTemplateDto.Status
        };
    }

    public static Template CreateTemplate(CreateTemplateDto createTemplateDto)
    {
        return new Template
        {
            Title = createTemplateDto.Title,
            Description = createTemplateDto.Description,
            Theme = createTemplateDto.Theme,
            ImageUrl = createTemplateDto.ImageUrl,
            Tags = createTemplateDto.Tags,
            Status = createTemplateDto.Status,
            TemplateCreatorId = createTemplateDto.TemplateCreatorId,
            Questions = createTemplateDto.Questions.Select(question => new Question
            {
                Title = question.Title,
                Type = question.Type,
                Options = question.Options?.Select(option => new QuestionOption
                {
                    Value = option.Value
                }).ToList()
            }).ToList()
        };
    }

    public static List<GetAllTemplatesForAdminDto> GetAllTemplatesForAdmin(List<Template> templates)
    {
        List<GetAllTemplatesForAdminDto> allTemplatesForAdmin = [];
        
        foreach (var template in templates)
        {
            var templateDto = new GetAllTemplatesForAdminDto
            {
                Id = template.Id,
                Title = template.Title,
                ImageUrl = template.ImageUrl,
                CountOfLikes = template.CountOfLikes
            };
            allTemplatesForAdmin.Add(templateDto);
        }

        return allTemplatesForAdmin;
    }
}