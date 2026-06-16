using System.Net;
using Forms.Application.Common.Mapping;
using Forms.Application.Common.Validators.QuestionValidators;
using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Common;
using Forms.Core.Exceptions;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionService(IQuestionRepository repository): IQuestionService
{
    private const string FieldNullOrEmptyErrorMessage = "The field can't be null or empty";
    public async Task<Result<bool>> AddQuestion(QuestionDto? questionDto)
    {
        if(questionDto == null)
            return Result<bool>.Failure("Bad Request", HttpStatusCode.BadRequest);

        var validator = new QuestionDtoValidator();
        var validationResult = await validator.ValidateAsync(questionDto);
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.ToDictionary());
        
        var question = QuestionMapping.AddQuestion(questionDto);
        await repository.AddQuestion(question);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteQuestion(uint? questionId)
    {
        if(questionId == null)
            throw new ValidationException("questionId", FieldNullOrEmptyErrorMessage);
        
        var questionResult = await GetById(questionId);
        if(!questionResult.IsSuccess) return Result<bool>.Failure(questionResult.ErrorMessage, HttpStatusCode.NotFound);
        
        var question = questionResult.Data;
        await repository.DeleteQuestion(question);
        return Result<bool>.Success(true);
    }

    public async Task<Result<Question>> GetById(uint? questionId)
    {
        if(questionId == null)
            throw new ValidationException("questionId", FieldNullOrEmptyErrorMessage);

        var question = await repository.GetById(questionId.Value);
        if  (question == null) 
            return Result<Question>.Failure("Question not found", HttpStatusCode.NotFound);
        
        return Result<Question>.Success(question);
    }

    public async Task<Result<List<Question>>> GetQuestionsByTemplateId(uint? templateId)
    {
        if(templateId == null)
            throw new ValidationException("templateId", FieldNullOrEmptyErrorMessage);

        var questions = await repository.GetQuestionsByTemplateId(templateId.Value);
        if(questions.Count == 0) 
            return Result<List<Question>>.Failure("No questions found", HttpStatusCode.NotFound);
        
        return Result<List<Question>>.Success(questions);
    }
}