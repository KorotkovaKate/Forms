using FluentValidation;
using Forms.Application.DTOs.QuestionDTOs;

namespace Forms.Application.Common.Validators.QuestionOptionValidators;

public class AddOptionDtoValidator: AbstractValidator<AddOptionDto>
{
    public AddOptionDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(dto => dto.QuestionId).NotNull().NotEmpty().WithMessage("Question Id Required");
        RuleFor(dto => dto.Value).NotNull().NotEmpty().WithMessage("Option can't be empty");
    }
}