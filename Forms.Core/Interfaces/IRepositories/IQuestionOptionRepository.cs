using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IQuestionOptionRepository
{
    public Task<List<QuestionOption>> GetOptions(uint questionId);
    public Task AddOption(QuestionOption questionOption);
    public Task DeleteOption(QuestionOption questionOption);
    public Task<QuestionOption?> GetOption(uint questionOptionId);
}