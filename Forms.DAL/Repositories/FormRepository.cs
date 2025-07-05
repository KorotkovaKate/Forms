using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class FormRepository(FormDbContext context): IFormRepository
{
    public async Task CreateForm(Form form)
    {
        context.Forms.Add(form);
        await context.SaveChangesAsync();
    }

    public async Task<Form?> GetFormById(uint formId)
    {
        return await context.Forms
            .AsNoTracking()
            .Include(form => form.Template)
            .Include(form => form.Submitter)
            .Include(form => form.Answers)
            .ThenInclude(answer => answer.Question)
            .FirstOrDefaultAsync(form => form.Id == formId);
    }

    public async Task<List<Form>?> GetFormsByUserId(uint userId)
    {
        return await context.Forms
            .AsNoTracking()
            .Include(form => form.Template)
            .Include(form => form.Answers)
            .ThenInclude(answer => answer.Question)
            .Where(form => form.SubmitterId == userId)
            .ToListAsync();
    }

    public async Task<List<Form>?> GetFormsByTemplateId(uint templateId)
    {
        return await context.Forms
            .AsNoTracking()
            .Include(form => form.Submitter)
            .Include(form => form.Template)
            .Include(form => form.Answers)
            .ThenInclude(answer => answer.Question)
            .Where(form => form.TemplateId == templateId)
            .ToListAsync();
    }
}