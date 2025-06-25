using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IQuestionService
{
    public Task AddQuestion(Question question);
    public Task DeleteQuestion(uint? questionId);
    public Task<Question?> GetById(uint? questionId);
    public Task<List<Question>> GetQuestionsByTemplateId(uint? templateId);
}