using Forms.Application.DTOs;
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

    public static List<GetAllCommentsByTemplateIdDto> GetAllComments(List<Comment> comments)
    {
        List<GetAllCommentsByTemplateIdDto> allComments = [];
        foreach (var comment in comments)
        {
            var commentDto = new GetAllCommentsByTemplateIdDto()
            {
                CommentId = comment.Id,
                CommentText = comment.Text,
                PublishTime = comment.PublishTime,
                UserName = comment.User.UserName,
            };
            allComments.Add(commentDto);
        }
        return allComments;
    }
}