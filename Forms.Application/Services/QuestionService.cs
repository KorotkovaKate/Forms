using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionService(IQuestionRepository repository): IQuestionService
{
    public async Task AddQuestion(Question question)
    {
        if (question is null) {throw new ArgumentNullException(nameof(question));}
        if (string.IsNullOrWhiteSpace(question.Title))
        {
            throw new ArgumentException("Incorrect question title or template id");
        }
        await repository.AddQuestion(question);
    }

    public async Task DeleteQuestion(uint? questionId)
    {
        var question = await GetById(questionId);
        if (question is null) {throw new ArgumentNullException(nameof(question));}
        await repository.DeleteQuestion(question);
    }

    public async Task<Question?> GetById(uint? questionId)
    {
        if (questionId == null) {throw new ArgumentException("Incorrect question id");}
        return await repository.GetById(questionId.Value);
    }

    public async Task<List<Question>> GetQuestionsByTemplateId(uint? templateId)
    {
        if  (templateId == null) {throw new ArgumentException("Incorrect template id");}
        return await repository.GetQuestionsByTemplateId(templateId.Value);
    }
}