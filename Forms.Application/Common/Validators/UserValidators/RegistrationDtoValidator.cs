using FluentValidation;
using Forms.Application.DTOs;

namespace Forms.Application.Common.Validators.UserValidators;

public class RegistrationDtoValidator: AbstractValidator<RegistrationDto>
{
    public RegistrationDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email is required");
        RuleFor(dto => dto.Email).EmailAddress().WithMessage("Email is invalid");
        RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Password is required");
        RuleFor(dto => dto.Password).MinimumLength(8).WithMessage("Password will be minimum 8 characters long");
        RuleFor(dto => dto.Username).NotNull().NotEmpty().WithMessage("Username is required");
    }
}