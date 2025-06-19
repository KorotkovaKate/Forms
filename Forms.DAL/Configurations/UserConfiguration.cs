using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user  => user.Id);
        builder.Property(user => user.Id).ValueGeneratedOnAdd();
        builder.HasIndex(user=> user.Email).IsUnique();
        builder.Property(user => user.Email).HasMaxLength(60).IsRequired();
        builder.Property(user => user.UserName).HasMaxLength(60).IsRequired();
        builder.Property(user => user.PasswordHash).IsRequired();
        
        builder
            .HasMany(user => user.Templates).WithOne(template => template.Creator)
            .HasForeignKey(template => template.TemplateCreatorId);
        
        builder
            .HasMany(user => user.Comments).WithOne(comment => comment.User)
            .HasForeignKey(comment => comment.UserId);
        
        builder.HasMany(user => user.LikedTemplates).WithOne(likedTemplate => likedTemplate.User)
            .HasForeignKey(likedTemplate => likedTemplate.UserId);
    }
}