using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IStatisticService
{
    public Task AddStatistic(Statistic statistic);
    public Task UpdateStatistic(uint statisticId, Statistic statistic);
    public Task<List<Statistic>> GetStatisticsByTemplateId(uint templateId);
}