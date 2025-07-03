using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionService(IQuestionRepository repository): IQuestionService
{
    public async Task AddQuestion(QuestionDto questionDto)
    {
        ArgumentNullException.ThrowIfNull(questionDto);
        if (string.IsNullOrWhiteSpace(questionDto.Title))
        {
            throw new ArgumentException("Incorrect question title or template id");
        }
        var question = QuestionMapping.AddQuestion(questionDto);
        await repository.AddQuestion(question);
    }

    public async Task DeleteQuestion(uint? questionId)
    {
        ArgumentNullException.ThrowIfNull(questionId, "Question id can't be null");
        var question = await GetById(questionId);
        await repository.DeleteQuestion(question);
    }

    public async Task<Question> GetById(uint? questionId)
    {
        ArgumentNullException.ThrowIfNull(questionId, "Question id is null");
        var question = await repository.GetById(questionId.Value);
        ArgumentNullException.ThrowIfNull(question, "question not found");
        return question;
    }

    public async Task<List<Question>> GetQuestionsByTemplateId(uint? templateId)
    {
        ArgumentNullException.ThrowIfNull(templateId, "Template id can't be null");
        var questions = await repository.GetQuestionsByTemplateId(templateId.Value);
        if(!questions.Any()) throw new ArgumentException("No questions found");
        return questions;
    }
}