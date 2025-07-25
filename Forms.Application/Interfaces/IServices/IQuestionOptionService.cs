using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IQuestionOptionService
{
    public Task<List<QuestionOption>> GetOptionsByQuestionId(uint? questionId);
    public Task AddOption(AddOptionDto addOptionDto);
    public Task DeleteOption(uint? questionOptionId);
    public Task<QuestionOption> GetOptionById(uint? questionOptionId);
}