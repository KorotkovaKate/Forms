using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class QuestionOptionConfiguration: IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.HasKey(questionOption => questionOption.Id);
        builder.Property(questionOption => questionOption.Id).ValueGeneratedOnAdd();
        builder.Property(questionOption => questionOption.Value).IsRequired();
        
        builder.HasOne(questionOption => questionOption.Question).WithMany(question => question.Options);
    }
}