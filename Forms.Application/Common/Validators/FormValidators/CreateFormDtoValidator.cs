using FluentValidation;
using Forms.Application.DTOs.FormDTOs;

namespace Forms.Application.Common.Validators.FormValidators;

public class CreateFormDtoValidator: AbstractValidator<CreateFormDto>
{
    public CreateFormDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(dto => dto.SubmitterId).NotNull().NotEmpty().WithMessage("Please specify a valid submitter ID");
        RuleFor(dto => dto.TemplateId).NotNull().NotEmpty().WithMessage("Please specify a valid Template ID");
        RuleFor(dto => dto.Answers).NotNull().NotEmpty().WithMessage("Form consist of 0 answers");
    }
}