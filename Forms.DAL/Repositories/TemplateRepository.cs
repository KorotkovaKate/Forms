using Forms.Core.Enums;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class TemplateRepository(FormDbContext context):ITemplateRepository
{
    public async Task CreateTemplate(Template template)
    {
        await context.Templates.AddAsync(template);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTemplate(Template template)
    {
        try
        {
            context.Templates.Remove(template);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while deleting the template", e);
        }
    }

    public async Task UpdateTemplate(uint templateId, Template updatedTemplate)
    {
        var template = await context.Templates.FindAsync(templateId);
        if (template != null)
        {
            template.Title = updatedTemplate.Title;
            template.Description = updatedTemplate.Description;
            template.Theme = updatedTemplate.Theme;
            template.ImageUrl = updatedTemplate.ImageUrl;
            template.Tags = updatedTemplate.Tags;
            template.Status = updatedTemplate.Status;
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Template>> GetAllPublicTemplates()
    {
        return await context.Templates
            .AsNoTracking()
            .Where(template => template.Status == TemplateStatus.Public)
            .ToListAsync();
    }

    public async Task<List<Template>?> GetAllTemplates()
    {
        return await context.Templates.AsNoTracking().ToListAsync();
    }

    public async Task<Template?> GetTemplateById(uint templateId)
    {
        return await context.Templates
            .AsNoTracking()
            .Include(template => template.Questions)
            .Include(template => template.Comments)
            .FirstOrDefaultAsync(template => template.Id == templateId);
    }

    public async Task IncreaseLikeNumber(Template template)
    {
        template.CountOfLikes += 1;
        await context.SaveChangesAsync();
    }
    public async Task DecreaseLikeNumber(Template template)
    {
        template.CountOfLikes -= 1;
        await context.SaveChangesAsync();
    }
}