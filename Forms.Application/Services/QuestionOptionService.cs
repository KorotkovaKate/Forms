using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionOptionService(IQuestionOptionRepository repository):IQuestionOptionService
{
    public async Task<List<QuestionOption>> GetOptionsByQuestionId(uint? questionId)
    {
        if (questionId == null) {throw new ArgumentNullException(nameof(questionId));}
        return await repository.GetOptionsByQuestionId(questionId.Value);
    }

    public async Task AddOption(QuestionOption questionOption)
    {
        if (questionOption is null) {throw new ArgumentNullException(nameof(questionOption));}
        if (string.IsNullOrWhiteSpace(questionOption.Value))
        {
            throw new ArgumentException("Incorrect value");
        }
        await repository.AddOption(questionOption);
    }

    public async Task DeleteOption(uint? questionOptionId)
    {
        var questionOption = await GetOptionById(questionOptionId);
        if (questionOption == null) {throw new ArgumentNullException(nameof(questionOptionId));}
        await repository.DeleteOption(questionOption);
    }

    public async Task<QuestionOption?> GetOptionById(uint? questionOptionId)
    {
        if (questionOptionId == null) {throw new ArgumentNullException(nameof(questionOptionId));}
        return await repository.GetOptionById(questionOptionId.Value);
    }
}