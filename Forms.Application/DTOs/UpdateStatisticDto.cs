using Forms.Core.Models;

namespace Forms.Application.DTOs;

public class UpdateStatisticDto
{
    public uint? StatisticId { get; set; }
    public Statistic Statistic { get; set; }
}