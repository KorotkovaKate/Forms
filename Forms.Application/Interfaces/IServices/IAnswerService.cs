using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IAnswerService
{
    public Task<List<Answer>> GetAnswersByFormId(uint formId);
    public Task AddAnswer(Answer answer);
}