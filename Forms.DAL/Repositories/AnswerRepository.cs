using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class AnswerRepository(FormDbContext context): IAnswerRepository
{
    public async Task<List<Answer>?> GetAnswersByFormId(uint formId)
    {
        return await context.Answers
            .AsNoTracking()
            .Include(answer => answer.Question)
            .Where(answer => answer.FormId == formId)
            .ToListAsync();
    }

    public async Task<List<Answer>?> GetAnswersByQuestionId(uint questionId)
    {
        return await context.Answers
            .AsNoTracking()
            .Where(answer => answer.QuestionId == questionId)
            .ToListAsync();
    }

    public async Task AddAnswer(Answer answer)
    {
        await context.Answers.AddAsync(answer);
        await context.SaveChangesAsync();
    }
}