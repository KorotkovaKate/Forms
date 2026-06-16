using FluentValidation;
using Forms.Application.DTOs.QuestionDTOs;

namespace Forms.Application.Common.Validators.QuestionValidators;

public class QuestionDtoValidator: AbstractValidator<QuestionDto>
{
    public QuestionDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(dto => dto.Title).NotNull().NotEmpty().WithMessage("Title is required");
        RuleFor(dto => dto.Type).NotEmpty().WithMessage("Title is required");
    }
}