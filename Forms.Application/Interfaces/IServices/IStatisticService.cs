using Forms.Application.DTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IStatisticService
{
    public Task<Result<bool>> AddStatistic(uint? questionId);
    public Task UpdateStatistic(UpdateStatisticDto updateStatisticDto);
    public Task<List<GetStatisticDto>> GetStatisticsByTemplateId(uint? templateId);
}