using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ICommentService
{
    public Task AddComment(Comment comment);
    public Task DeleteComment(uint? comment);
    public Task<Comment?> GetCommentById(uint? commentId);
    public Task UpdateComment(UpdateMessageDto updateMessageDto);
    public Task<List<Comment>> GetAllCommentsByTemplateId(uint? templateId);
}