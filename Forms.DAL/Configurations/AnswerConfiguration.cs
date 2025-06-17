using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class AnswerConfiguration: IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(answer => answer.Id);
        builder.Property(answer => answer.Id).ValueGeneratedOnAdd();
        builder.Property(answer => answer.Value).IsRequired();
        
        builder.HasOne(answer => answer.Question).WithMany().HasForeignKey(answer => answer.QuestionId);
        builder.HasOne(answer => answer.Form).WithMany(form => form.Answers);
    }
}