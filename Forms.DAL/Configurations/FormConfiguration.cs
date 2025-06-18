using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class FormConfiguration: IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(form => form.Id);
        builder.Property(form => form.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(form => form.Submitter).WithMany(user => user.Forms)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(form => form.Template).WithMany().HasForeignKey(form => form.TemplateId);
        builder.HasMany(form => form.Answers).WithOne(answer => answer.Form)
            .HasForeignKey(answer => answer.FormId);
    }
}