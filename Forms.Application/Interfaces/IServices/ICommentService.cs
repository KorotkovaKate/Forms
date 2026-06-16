using System.Collections.Generic;
using System.Threading.Tasks;
using Forms.Application.DTOs;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ICommentService
{
    public Task<Result<bool>> AddComment(AddCommentDto? addCommentDto);
    public Task<Result<bool>> DeleteComment(uint? comment);
    public Task<Result<Comment>> GetCommentById(uint? commentId);
    public Task<Result<bool>> UpdateComment(UpdateCommentDto? updateCommentDto);
    public Task<Result<List<GetAllCommentsByTemplateIdDto>>> GetAllCommentsByTemplateId(uint? templateId);
}