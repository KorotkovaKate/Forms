using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class LikedTemplateRepository(FormDbContext context): ILikedTemplateRepository
{
    public async Task<List<Template>> GetLikedTemplatesByUserId(uint userId)
    {
        return await context.LikedTemplates
            .Where(likedTemplates => likedTemplates.UserId == userId)
            .Include(likedTemplates => likedTemplates.Template)
            .Select(likedTemplates => likedTemplates.Template)
            .ToListAsync();
    }

    public async Task AddLikedTemplate(LikedTemplate likedTemplate)
    {
        await context.LikedTemplates.AddAsync(likedTemplate);
        await context.SaveChangesAsync();
    }

    public async Task RemoveLikedTemplate(LikedTemplate likedTemplate)
    {
        context.LikedTemplates.Remove(likedTemplate);
        await context.SaveChangesAsync();
    }
}