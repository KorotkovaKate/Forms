using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IQuestionService
{
    public Task<Result<bool>> AddQuestion(QuestionDto questionDto);
    public Task<Result<bool>> DeleteQuestion(uint? questionId);
    public Task<Result<Question>> GetById(uint? questionId);
    public Task<Result<List<Question>>> GetQuestionsByTemplateId(uint? templateId);
}