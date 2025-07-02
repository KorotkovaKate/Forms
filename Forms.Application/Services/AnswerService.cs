using Forms.Application.DTOs.AnswerDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
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

    public async Task AddAnswer(AddAnswerDto addAnswerDto)
    {
        if (addAnswerDto == null) {throw new ArgumentException("Incorrect answer");}
        var answer = AnswerMapping.AddAnswer(addAnswerDto);
        await repository.AddAnswer(answer);
    }
}