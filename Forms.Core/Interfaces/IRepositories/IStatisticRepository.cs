using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IStatisticRepository
{
    public Task AddStatistic(Statistic statistic);
    public Task UpdateStatistic(Statistic updatedStatistic);
    public Task<List<Statistic>> GetStatisticsByTemplateId(uint templateId);
    
}