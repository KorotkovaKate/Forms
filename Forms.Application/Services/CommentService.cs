using System.Net;
using Forms.Application.DTOs;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class CommentService(ICommentRepository repository): ICommentService
{
    public async Task<Result<bool>> AddComment(AddCommentDto? addCommentDto)
    {
        if (addCommentDto == null || addCommentDto.UserId == null
                                  || addCommentDto.TemplateId == null
                                  || string.IsNullOrWhiteSpace(addCommentDto.Text))
        {
            throw new ArgumentException("Incorrect comment");
        } //flvalid
        
        var comment = CommentMapping.AddComment(addCommentDto);
        await repository.AddComment(comment);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteComment(uint? commentId)
    {
        if (commentId == null) 
            return Result<bool>.Failure("Invalid comment id", HttpStatusCode.BadRequest);
        
        var commentResult = await GetCommentById(commentId);
        if (!commentResult.IsSuccess) 
            return Result<bool>.Failure(commentResult.ErrorMessage, HttpStatusCode.NotFound);
        
        var comment = commentResult.Data;
        await repository.DeleteComment(comment);
        
        return Result<bool>.Success(true);
    }

    public async Task<Result<Comment>> GetCommentById(uint? commentId)
    {
        if  (commentId == null) 
            return Result<Comment>.Failure("Invalid comment id", HttpStatusCode.BadRequest);
        
        var comment = await repository.GetCommentById(commentId.Value);
        if(comment == null) 
            return Result<Comment>.Failure("Comment not found", HttpStatusCode.NotFound);
        
        return Result<Comment>.Success(comment);
    }

    public async Task<Result<bool>> UpdateComment(UpdateCommentDto? updateCommentDto)
    {
        if(updateCommentDto == null || updateCommentDto.Id == null) throw new Exception("Message cant be found"); //flvalid
        if(string.IsNullOrWhiteSpace(updateCommentDto.Text)) throw new Exception("Text to edit cant be empty");
        
        await repository.UpdateComment(updateCommentDto.Id.Value, updateCommentDto.Text);
        return Result<bool>.Success(true);
    }

    public async Task<Result<List<GetAllCommentsByTemplateIdDto>>> GetAllCommentsByTemplateId(uint? templateId)
    {
        if  (templateId == null) 
            return Result<List<GetAllCommentsByTemplateIdDto>>
                .Failure("Invalid template", HttpStatusCode.BadRequest);
        
        var comments = await repository.GetAllCommentsByTemplateId(templateId.Value);
        if(comments.Count == 0) 
            return Result<List<GetAllCommentsByTemplateIdDto>>
                .Failure("No comments found", HttpStatusCode.NotFound);
        
        var response = CommentMapping.GetAllComments(comments);
        return Result<List<GetAllCommentsByTemplateIdDto>>.Success(response);
    }
}