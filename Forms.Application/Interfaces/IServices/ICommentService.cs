using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ICommentService
{
    public Task AddComment(Comment comment);
    public Task DeleteComment(Comment comment);
    public Task<Comment?> GetCommentById(uint commentId);
    public Task UpdateComment(uint commentId, string textToEdit);
    public Task<List<Comment>> GetAllCommentsByTemplateId(uint templateId);
}