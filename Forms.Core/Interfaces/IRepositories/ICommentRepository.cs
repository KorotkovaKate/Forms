using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface ICommentRepository
{
    public Task AddComment(Comment comment);
    public Task DeleteComment(uint commentId);
    public Task UpdateComment(uint commentId, string textToEdit);
    public Task<List<Comment>> GetAllCommentsByTemplateId(uint templateId);
}