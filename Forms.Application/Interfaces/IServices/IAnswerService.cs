using Forms.Application.DTOs.AnswerDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface 
    IAnswerService
{
    public Task<Result<List<Answer>>> GetAnswersByFormId(uint? formId);
    public Task<Result<List<Answer>>> GetAnswersByQuestionId(uint? questionId);
}