using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class CommentRepository(FormDbContext context): ICommentRepository
{
    public async Task AddComment(Comment comment)
    {
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
    }

    public async Task DeleteComment(Comment comment)
    {
        try
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while deleting the question", e);
        }
    }

    public async Task<Comment?> GetCommentById(uint commentId)
    {
        return await context.Comments
            .AsNoTracking()
            .Include(comment => comment.User)
            .FirstOrDefaultAsync(comment => comment.Id == commentId);
    }

    public async Task UpdateComment(uint commentId, string textToEdit)
    {
        var comment = await context.Comments.FindAsync(commentId);
        if (comment is not null)
        {
            comment.Text = textToEdit;
            comment.PublishTime = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Comment>> GetAllCommentsByTemplateId(uint templateId)
    {
        return await context.Comments
            .AsNoTracking()
            .Include(comment => comment.User)
            .Where(comment => comment.TemplateId == templateId)
            .ToListAsync();
    }
}