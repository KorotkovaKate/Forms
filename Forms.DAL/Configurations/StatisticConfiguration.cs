using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forms.DAL.Configurations;

public class StatisticConfiguration: IEntityTypeConfiguration<Statistic>
{
    public void Configure(EntityTypeBuilder<Statistic> builder)
    {
        builder.HasKey(statistic => statistic.Id);
        builder.Property(statistic => statistic.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(statistic => statistic.Template).WithMany(template => template.Statistics)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(statistic => statistic.Question).WithOne(question => question.Statistic)
            .HasForeignKey<Statistic>(statistic => statistic.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);;
    }
}