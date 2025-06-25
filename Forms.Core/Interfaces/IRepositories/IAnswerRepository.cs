using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IAnswerRepository
{
    public Task<List<Answer>> GetAnswersByFormId(uint formId);
    public Task<List<Answer>> GetAnswerByQuestionId(uint questionId);
    public Task AddAnswer(Answer answer);
}