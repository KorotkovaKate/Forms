using FluentValidation;
using Forms.Application.DTOs.UserDTOs;

namespace Forms.Application.Common.Validators.UserValidators;

public class AuthorizationDtoValidator: AbstractValidator<AuthorizationDto>
{
    public AuthorizationDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email is required");
        RuleFor(dto => dto.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Password is required");
        RuleFor(dto => dto.Password).MinimumLength(8).WithMessage("Password will be minimum 8 characters long");
    }
}