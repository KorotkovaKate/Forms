using System.Net;
using Forms.Application.Common.Mapping;
using Forms.Application.Common.Validators.QuestionOptionValidators;
using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Exceptions;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionOptionService(IQuestionOptionRepository repository):IQuestionOptionService
{
    private const string FieldNullErrorMessage = "The field can't be null";
    public async Task<Result<List<QuestionOption>>> GetOptionsByQuestionId(uint? questionId)
    {
        if (questionId == null) {throw new ValidationException("questionId", FieldNullErrorMessage);}
        
        var options = await repository.GetOptionsByQuestionId(questionId.Value);
        if (options.Count == 0)
            Result<List<QuestionOption>>.Failure("No options found", HttpStatusCode.InternalServerError);
        
        return Result<List<QuestionOption>>.Success(options);
    }

    public async Task<Result<bool>> AddOption(AddOptionDto? addOptionDto)
    {
        if(addOptionDto == null)
            return Result<bool>.Failure("Bad Request", HttpStatusCode.BadRequest);
        
        var validator = new AddOptionDtoValidator();
        var validationResult = await validator.ValidateAsync(addOptionDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.ToDictionary());
        
        var questionOption = QuestionOptionMapping.AddOption(addOptionDto);
        await repository.AddOption(questionOption);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteOption(uint? questionOptionId)
    {
        if (questionOptionId == null) throw new ValidationException("questionOptionId", FieldNullErrorMessage);
        
        var questionOptionResult = await GetOptionById(questionOptionId);
        if (!questionOptionResult.IsSuccess) 
            return Result<bool>.Failure(questionOptionResult.ErrorMessage, HttpStatusCode.NotFound);
        
        var response = questionOptionResult.Data;
        await repository.DeleteOption(response);
        return Result<bool>.Success(true);
    }

    public async Task<Result<QuestionOption>> GetOptionById(uint? questionOptionId)
    {
        if (questionOptionId == null)
            throw new ValidationException("questionOptionId", FieldNullErrorMessage);
        
        var questionOption = await repository.GetOptionById(questionOptionId.Value);
        if (questionOption == null) 
            return Result<QuestionOption>.Failure("Question option not found", HttpStatusCode.NotFound);
        
        return Result<QuestionOption>.Success(questionOption);
    }
}