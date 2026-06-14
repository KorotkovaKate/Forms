using System.Collections.Generic;
using System.Threading.Tasks;
using Forms.Application.DTOs;
using Forms.Application.DTOs.StatisticDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IStatisticService
{
    public Task<Result<bool>> AddStatistic(uint? questionId);
    public Task<Result<bool>> UpdateStatistic(UpdateStatisticDto? updateStatisticDto);
    public Task<Result<List<GetStatisticDto>>> GetStatisticsByTemplateId(uint? templateId);
    public Task<Result<bool>> RecalculateTemplateStatistics(uint templateId);
}