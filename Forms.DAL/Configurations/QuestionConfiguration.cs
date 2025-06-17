using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class QuestionConfiguration: IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(question => question.Id);
        builder.Property(question => question.Id).ValueGeneratedOnAdd();
        builder.Property(question => question.Title).IsRequired();
        builder.Property(question => question.Type).IsRequired();
        
        builder.HasOne(question => question.Template).WithMany(template => template.Questions);
        builder.HasMany(question => question.Options).WithOne(option => option.Question)
            .HasForeignKey(option => option.QuestionId);
    }
}