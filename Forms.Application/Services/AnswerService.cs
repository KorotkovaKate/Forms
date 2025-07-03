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
        var answers = await repository.GetAnswersByFormId(formId.Value);
        if(answers == null) throw new ArgumentException("No answers found");
        return answers;
    }

    public async Task<List<Answer>> GetAnswersByQuestionId(uint? questionId)
    {
        if  (questionId == null) {throw new ArgumentException("Incorrect questionId");}
        var answers = await repository.GetAnswersByQuestionId(questionId.Value);
        if(answers == null) throw new ArgumentException("No answers found");
        return answers;
    }
}