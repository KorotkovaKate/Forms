using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IQuestionOptionRepository
{
    public Task<List<QuestionOption>> GetOptions(uint questionId);
}