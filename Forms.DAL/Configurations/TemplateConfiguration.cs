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
    }
}