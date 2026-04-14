using System.Net;
using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionService(IQuestionRepository repository): IQuestionService
{
    public async Task<Result<bool>> AddQuestion(QuestionDto? questionDto)
    {
        if(questionDto == null)
            return Result<bool>.Failure("Bad Request", HttpStatusCode.BadRequest);
        
        if (string.IsNullOrWhiteSpace(questionDto.Title))
        {
            throw new ArgumentException("Incorrect question title or template id");
        } //flvalid
        
        var question = QuestionMapping.AddQuestion(questionDto);
        await repository.AddQuestion(question);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteQuestion(uint? questionId)
    {
        ArgumentNullException.ThrowIfNull(questionId, "Question id can't be null"); //flvalid
        var questionResult = await GetById(questionId);
        if(!questionResult.IsSuccess) return Result<bool>.Failure(questionResult.ErrorMessage, HttpStatusCode.NotFound);
        
        var question = questionResult.Data;
        await repository.DeleteQuestion(question);
        return Result<bool>.Success(true);
    }

    public async Task<Result<Question>> GetById(uint? questionId)
    {
        ArgumentNullException.ThrowIfNull(questionId, "Question id is null");
        //flvalid
        var question = await repository.GetById(questionId.Value);
        if  (question == null) 
            return Result<Question>.Failure("Question not found", HttpStatusCode.NotFound);
        
        return Result<Question>.Success(question);
    }

    public async Task<Result<List<Question>>> GetQuestionsByTemplateId(uint? templateId)
    {
        ArgumentNullException.ThrowIfNull(templateId, "Template id can't be null"); //flvalid
        
        var questions = await repository.GetQuestionsByTemplateId(templateId.Value);
        if(questions.Count == 0) 
            return Result<List<Question>>.Failure("No questions found", HttpStatusCode.NotFound);
        
        return Result<List<Question>>.Success(questions);
    }
}