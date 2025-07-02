using Forms.Application.DTOs.CommentDTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class CommentMapping
{
    public static Comment AddComment(AddCommentDto addCommentDto)
    {
        return new Comment
        {
            UserId = addCommentDto.UserId.Value,
            TemplateId = addCommentDto.TemplateId.Value,
            Text = addCommentDto.Text,
        };
    }
}