using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IStatisticService
{
    public Task AddStatistic(uint? questionId);
    public Task UpdateStatistic(UpdateStatisticDto updateStatisticDto);
    public Task<List<GetStatisticDto>> GetStatisticsByTemplateId(uint? templateId);
}