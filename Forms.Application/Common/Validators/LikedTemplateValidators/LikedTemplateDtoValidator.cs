using FluentValidation;
using Forms.Application.DTOs;

namespace Forms.Application.Common.Validators.LikedTemplateValidators;

public class LikedTemplateDtoValidator: AbstractValidator<LikedTemplateDto>
{
    public LikedTemplateDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(dto => dto.UserId).NotNull().NotEmpty().WithMessage("User Id Required");
        RuleFor(dto => dto.TemplateId).NotNull().NotEmpty().WithMessage("Template Id Required");
    }
}