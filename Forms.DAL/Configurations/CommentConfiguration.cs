using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class CommentConfiguration: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(comment => comment.Id);
        builder.Property(comment => comment.Id).ValueGeneratedOnAdd();
        builder.Property(comment => comment.Text).IsRequired();
        
        builder.HasOne(comment => comment.User).WithMany(user => user.Comments)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(comment => comment.Template).WithMany(template => template.Comments)
            .OnDelete(DeleteBehavior.NoAction);
    }
}