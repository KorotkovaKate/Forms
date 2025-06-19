using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class LikedTemplateConfiguration: IEntityTypeConfiguration<LikedTemplate>
{
    public void Configure(EntityTypeBuilder<LikedTemplate> builder)
    {
        builder.HasKey(likedTemplate => likedTemplate.Id);
        builder.Property(likedTemplate => likedTemplate.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(likedTemplate => likedTemplate.Template).WithMany()
            .HasForeignKey(likedTemplate => likedTemplate.TemplateId);
        
        builder.HasOne(likedTemplate => likedTemplate.User).WithMany(user => user.LikedTemplates)
            .OnDelete(DeleteBehavior.Restrict);
    }
}