using Forms.Core.Models;
using Forms.DAL.Configurations;
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
    public DbSet<LikedTemplate>  LikedTemplates { get; set; }
    public DbSet<Statistic>  Statistics { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionOptionConfiguration());
        modelBuilder.ApplyConfiguration(new FormConfiguration());
        modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new LikedTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new StatisticConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}