using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class CommentService(ICommentRepository repository): ICommentService
{
    public async Task AddComment(Comment comment)
    {
        if (comment == null) {throw new ArgumentException("Incorrect comment");}
        await repository.AddComment(comment);
    }

    public async Task DeleteComment(uint? commentId)
    {
        var comment = await GetCommentById(commentId);
        if (comment == null) {throw new ArgumentException("Incorrect comment");}
        await repository.DeleteComment(comment);
    }

    public Task<Comment?> GetCommentById(uint? commentId)
    {
        if  (commentId == null) {throw new ArgumentException("Incorrect commentId");}
        return repository.GetCommentById(commentId.Value);
    }

    public async Task UpdateComment(UpdateMessageDto updateMessageDto)
    {
        if(updateMessageDto.Id == null) throw new Exception("Message cant be found");
        if(string.IsNullOrWhiteSpace(updateMessageDto.Text)) throw new Exception("Text to edit cant be empty");
        await repository.UpdateComment(updateMessageDto.Id.Value, updateMessageDto.Text);
    }

    public Task<List<Comment>> GetAllCommentsByTemplateId(uint? templateId)
    {
        if  (templateId == null) {throw new ArgumentException("Incorrect templateId");}
        return repository.GetAllCommentsByTemplateId(templateId.Value);
    }
}