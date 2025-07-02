using Forms.Application.DTOs.AnswerDTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IAnswerService
{
    public Task<List<Answer>> GetAnswersByFormId(uint? formId);
    public Task<List<Answer>> GetAnswerByQuestionId(uint? questionId);
    public Task AddAnswer(AddAnswerDto addAnswerDto);
}