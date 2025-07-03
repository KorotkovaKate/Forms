using Forms.Application.DTOs;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class CommentService(ICommentRepository repository): ICommentService
{
    public async Task AddComment(AddCommentDto addCommentDto)
    {
        if (addCommentDto == null || addCommentDto.UserId == null
                                  || addCommentDto.TemplateId == null
                                  || string.IsNullOrWhiteSpace(addCommentDto.Text))
        {
            throw new ArgumentException("Incorrect comment");
        }
        var comment = CommentMapping.AddComment(addCommentDto);
        await repository.AddComment(comment);
    }

    public async Task DeleteComment(uint? commentId)
    {
        if (commentId == null) throw new ArgumentException("Id can't be null");
        var comment = await GetCommentById(commentId);
        if (comment == null) {throw new ArgumentException("Comment not found");}
        await repository.DeleteComment(comment);
    }

    public async Task<Comment> GetCommentById(uint? commentId)
    {
        if  (commentId == null) {throw new ArgumentException("Incorrect commentId");}
        var comment = await repository.GetCommentById(commentId.Value);
        if(comment == null) {throw new ArgumentException("Comment not found");}
        return comment;
    }

    public async Task UpdateComment(UpdateCommentDto updateCommentDto)
    {
        if(updateCommentDto == null || updateCommentDto.Id == null) throw new Exception("Message cant be found");
        if(string.IsNullOrWhiteSpace(updateCommentDto.Text)) throw new Exception("Text to edit cant be empty");
        await repository.UpdateComment(updateCommentDto.Id.Value, updateCommentDto.Text);
    }

    public async Task<List<Comment>> GetAllCommentsByTemplateId(uint? templateId)
    {
        if  (templateId == null) {throw new ArgumentException("Incorrect templateId");}
        var comments = await repository.GetAllCommentsByTemplateId(templateId.Value);
        if(comments == null) throw new ArgumentException("Comments not found");
        return comments;
    }
}