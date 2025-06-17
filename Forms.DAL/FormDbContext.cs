using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL;

public class FormDbContext(DbContextOptions<FormDbContext> options): DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
}