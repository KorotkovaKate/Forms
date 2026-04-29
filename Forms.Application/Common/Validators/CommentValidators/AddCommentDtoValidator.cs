using FluentValidation;
using Forms.Application.DTOs.CommentDTOs;

namespace Forms.Application.Common.Validators.CommentValidators;

public class AddCommentDtoValidator: AbstractValidator<AddCommentDto>
{
    public AddCommentDtoValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(dto => dto.TemplateId).NotEmpty().NotNull().WithMessage("TemplateId is required");
        RuleFor(dto => dto.Text).NotEmpty().NotNull().WithMessage("Text of the comment is required");
        RuleFor(dto => dto.UserId).NotEmpty().NotNull().WithMessage("UserId is required");
    }
}