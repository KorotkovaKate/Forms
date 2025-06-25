using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class AnswerService(IAnswerRepository repository): IAnswerService
{
    public async Task<List<Answer>> GetAnswersByFormId(uint? formId)
    {
        if (formId == null) {throw new ArgumentException("Incorrect form id");}
        return await repository.GetAnswersByFormId(formId.Value);
    }

    public Task<List<Answer>> GetAnswerByQuestionId(uint? questionId)
    {
        if  (questionId == null) {throw new ArgumentException("Incorrect questionId");}
        return repository.GetAnswerByQuestionId(questionId.Value);
    }

    public async Task AddAnswer(Answer answer)
    {
        if (answer == null) {throw new ArgumentException("Incorrect answer");}
        await repository.AddAnswer(answer);
    }
}