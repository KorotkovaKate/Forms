using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class QuestionOptionService(IQuestionOptionRepository repository):IQuestionOptionService
{
    public async Task<List<QuestionOption>> GetOptionsByQuestionId(uint? questionId)
    {
        if (questionId == null) {throw new ArgumentNullException("Incorrect question ID");}
        var options = await repository.GetOptionsByQuestionId(questionId.Value);
        if (!options.Any()) throw new Exception("No options found");
        return options;
    }

    public async Task AddOption(AddOptionDto addOptionDto)
    {
        if (addOptionDto is null) throw new ArgumentNullException("Input data can't be null");
        if (string.IsNullOrWhiteSpace(addOptionDto.Value)) throw new ArgumentException("Incorrect value");
        if (addOptionDto.QuestionId == null) throw new ArgumentException("Incorrect question ID");
        var questionOption = QuestionOptionMapping.AddOption(addOptionDto);
        await repository.AddOption(questionOption);
    }

    public async Task DeleteOption(uint? questionOptionId)
    {
        if (questionOptionId == null) throw new ArgumentNullException("Incorrect question ID");
        var questionOption = await GetOptionById(questionOptionId);
        if (questionOption == null) {throw new ArgumentNullException(nameof(questionOptionId));}
        await repository.DeleteOption(questionOption);
    }

    public async Task<QuestionOption> GetOptionById(uint? questionOptionId)
    {
        if (questionOptionId == null) {throw new ArgumentNullException(nameof(questionOptionId));}
        var questionOption = await GetOptionById(questionOptionId);
        if (questionOption == null) {throw new ArgumentNullException("Question option not found");}
        return questionOption;
    }
}