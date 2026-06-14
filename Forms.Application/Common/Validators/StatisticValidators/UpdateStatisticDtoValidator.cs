using FluentValidation;
using Forms.Application.DTOs;

namespace Forms.Application.Common.Validators.StatisticValidators;

public class UpdateStatisticDtoValidator:  AbstractValidator<UpdateStatisticDto>
{
    public UpdateStatisticDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(dto => dto.QuestionId).NotNull().NotEmpty().WithMessage("Question Id can't be empty");
        RuleFor(dto => dto.TemplateId).NotNull().NotEmpty().WithMessage("Template Id cannot be empty");
        RuleFor(dto => dto.StatisticId).NotNull().NotEmpty().WithMessage("Statistic Id cannot be empty");
    }
}