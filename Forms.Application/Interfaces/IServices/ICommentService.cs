using Forms.Application.DTOs;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ICommentService
{
    public Task AddComment(AddCommentDto addCommentDto);
    public Task DeleteComment(uint? comment);
    public Task<Comment?> GetCommentById(uint? commentId);
    public Task UpdateComment(UpdateCommentDto updateCommentDto);
    public Task<List<Comment>> GetAllCommentsByTemplateId(uint? templateId);
}