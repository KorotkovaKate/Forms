using FluentValidation;
using Forms.Application.DTOs.TemplateDTOs;

namespace Forms.Application.Common.Validators.TemplateValidators;

public class CreateTemplateDtoValidator:  AbstractValidator<CreateTemplateDto>
{
    public CreateTemplateDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(dto => dto.Title).NotNull().NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description cannot be empty");
    }
}