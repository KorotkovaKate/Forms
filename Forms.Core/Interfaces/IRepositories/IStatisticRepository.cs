using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IStatisticRepository
{
    public Task AddStatistic(Statistic statistic);
    public Task UpdateStatistic(uint statisticId, Statistic statistic);
    public Task<List<Statistic>> GetStatisticsByTemplateId(uint templateId);
    
}