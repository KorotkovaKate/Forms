using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class StatisticRepository(FormDbContext context): IStatisticRepository
{
    public async Task AddStatistic(Statistic statistic)
    {
        await context.Statistics.AddAsync(statistic);
        await context.SaveChangesAsync();
    }

    public async Task UpdateStatistic(Statistic updatedStatistic)
    {
        var statistic = await context.Statistics.FindAsync(updatedStatistic.Id);
        if (statistic is not null)
        {
            statistic.AnswerFrequencyInPercent = updatedStatistic.AnswerFrequencyInPercent;
            statistic.MostCommonAnswer = updatedStatistic.MostCommonAnswer;
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Statistic>> GetStatisticsByTemplateId(uint templateId)
    {
        return await context.Statistics
            .Include(statistic => statistic.Question)
            .Where(statistic => statistic.TemplateId == templateId)
            .ToListAsync();
    }
}