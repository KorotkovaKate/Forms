using System.Net;
using Forms.Application.DTOs.AnswerDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class AnswerService(IAnswerRepository repository): IAnswerService
{
    public async Task<Result<List<Answer>>> GetAnswersByFormId(uint? formId)
    {
        if (formId == null) 
            return Result<List<Answer>>.Failure("Incorrect form ID", HttpStatusCode.BadRequest);
        var answers = await repository.GetAnswersByFormId(formId.Value);
        return Result<List<Answer>>.Success(answers);
    }

    public async Task<Result<List<Answer>>> GetAnswersByQuestionId(uint? questionId)
    {
        if  (questionId == null) 
            return Result<List<Answer>>.Failure("Incorrect question ID", HttpStatusCode.BadRequest);
        var answers = await repository.GetAnswersByQuestionId(questionId.Value);
        return Result<List<Answer>>.Success(answers);
    }
}