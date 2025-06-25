using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class QuestionOptionRepository(FormDbContext context): IQuestionOptionRepository
{
    public async Task<List<QuestionOption>> GetOptionsByQuestionId(uint questionId)
    {
        return await context.QuestionOptions
            .Where(question => question.QuestionId == questionId)
            .ToListAsync();
    }

    public async Task AddOption(QuestionOption questionOption)
    {
        await context.QuestionOptions.AddAsync(questionOption);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOption(QuestionOption questionOption)
    {
        try
        {
            context.QuestionOptions.Remove(questionOption);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while deleting the question", e);
        }
    }

    public async Task<QuestionOption?> GetOptionById(uint questionOptionId)
    {
        return await context.QuestionOptions
            .FirstOrDefaultAsync(questionOption => questionOption.Id == questionOptionId);
    }
}