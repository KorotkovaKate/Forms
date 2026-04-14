using System.Net;
using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionOptionService(IQuestionOptionRepository repository):IQuestionOptionService
{
    public async Task<Result<List<QuestionOption>>> GetOptionsByQuestionId(uint? questionId)
    {
        if (questionId == null) {throw new ArgumentNullException("Incorrect question ID");} //flvalid
        
        var options = await repository.GetOptionsByQuestionId(questionId.Value);
        if (options.Count == 0)
            Result<List<QuestionOption>>.Failure("No options found", HttpStatusCode.InternalServerError);
        
        return Result<List<QuestionOption>>.Success(options);
    }

    public async Task<Result<bool>> AddOption(AddOptionDto? addOptionDto)
    {
        if (addOptionDto is null) throw new ArgumentNullException("Input data can't be null"); //flvalid
        if (string.IsNullOrWhiteSpace(addOptionDto.Value)) throw new ArgumentException("Incorrect value"); 
        if (addOptionDto.QuestionId == null) throw new ArgumentException("Incorrect question ID");
        
        var questionOption = QuestionOptionMapping.AddOption(addOptionDto);
        await repository.AddOption(questionOption);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteOption(uint? questionOptionId)
    {
        if (questionOptionId == null) throw new ArgumentNullException("Incorrect question ID"); //flvalid
        
        var questionOptionResult = await GetOptionById(questionOptionId);
        if (!questionOptionResult.IsSuccess) 
            return Result<bool>.Failure(questionOptionResult.ErrorMessage, HttpStatusCode.NotFound);
        
        var response = questionOptionResult.Data;
        await repository.DeleteOption(response);
        return Result<bool>.Success(true);
    }

    public async Task<Result<QuestionOption>> GetOptionById(uint? questionOptionId)
    {
        if (questionOptionId == null) {throw new ArgumentNullException(nameof(questionOptionId));} //flvalid
        
        var questionOption = await repository.GetOptionById(questionOptionId.Value);
        if (questionOption == null) 
            return Result<QuestionOption>.Failure("Question option not found", HttpStatusCode.NotFound);
        
        return Result<QuestionOption>.Success(questionOption);
    }
}