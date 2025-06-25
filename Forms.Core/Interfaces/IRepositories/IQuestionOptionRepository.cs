using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IQuestionOptionRepository
{
    public Task<List<QuestionOption>> GetOptionsByQuestionId(uint questionId);
    public Task AddOption(QuestionOption questionOption);
    public Task DeleteOption(QuestionOption questionOption);
    public Task<QuestionOption?> GetOptionById(uint questionOptionId);
}