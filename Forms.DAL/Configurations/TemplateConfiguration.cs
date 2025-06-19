using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class TemplateConfiguration: IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.HasKey(template => template.Id);
        builder.Property(template => template.Id).ValueGeneratedOnAdd();
        builder.Property(template => template.Title).IsRequired();
        builder.Property(template => template.Description).IsRequired();
        builder.Property(template => template.Theme).IsRequired();
        builder.Property(template => template.Status).IsRequired();
        
        builder.HasOne(template => template.Creator).WithMany(user => user.Templates);
        
        builder.HasMany(template => template.Questions).WithOne(question => question.Template)
            .HasForeignKey(question => question.TemplateId);
        
        builder.HasMany(template => template.Comments).WithOne(comment => comment.Template)
            .HasForeignKey(comment => comment.TemplateId);
        
        builder.HasMany(template => template.Forms).WithOne(form => form.Template)
            .HasForeignKey(form => form.TemplateId);

        builder.HasMany(template => template.Statistics).WithOne(statistic => statistic.Template)
            .HasForeignKey(statistic => statistic.TemplateId);
    }
}