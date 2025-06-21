using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IQuestionOptionService
{
    public Task<List<QuestionOption>> GetOptions(uint questionId);
    public Task AddOption(QuestionOption questionOption);
    public Task DeleteOption(QuestionOption questionOption);
    public Task<QuestionOption?> GetOption(uint questionOptionId);
}