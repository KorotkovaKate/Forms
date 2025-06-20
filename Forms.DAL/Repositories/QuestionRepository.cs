using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class QuestionRepository(FormDbContext context): IQuestionRepository
{
    public async Task AddQuestion(Question question)
    {
        await context.Questions.AddAsync(question);
        await context.SaveChangesAsync();
    }

    public async Task DeleteQuestion(Question question)
    {
        try
        {
            context.Questions.Remove(question);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while deleting the question", e);
        }
    }

    public async Task<Question?> GetById(uint questionId)
    {
        return await context.Questions
            .AsNoTracking()
            .Include(question => question.Options)
            .FirstOrDefaultAsync(question => question.Id == questionId);
    }

    public async Task<List<Question>> GetQuestionsByTemplateId(uint templateId)
    {
        return await context.Questions
            .AsNoTracking()
            .Include(question => question.Options)
            .Where(question => question.TemplateId == templateId)
            .ToListAsync();
    }
}