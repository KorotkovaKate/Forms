using System.Collections.Generic;
using System.Threading.Tasks;
using Forms.Application.DTOs.QuestionDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IQuestionOptionService
{
    public Task<Result<List<QuestionOption>>> GetOptionsByQuestionId(uint? questionId);
    public Task<Result<bool>> AddOption(AddOptionDto? addOptionDto);
    public Task<Result<bool>> DeleteOption(uint? questionOptionId);
    public Task<Result<QuestionOption>> GetOptionById(uint? questionOptionId);
}