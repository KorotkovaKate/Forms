using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IAnswerRepository
{
    public Task<List<Answer>?> GetAnswersByFormId(uint formId);
    public Task<List<Answer>?> GetAnswersByQuestionId(uint questionId);
    public Task AddAnswer(Answer answer);
}