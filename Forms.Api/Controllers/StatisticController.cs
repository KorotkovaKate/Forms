using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Statistic")]
public class StatisticController(IStatisticService  service): ControllerBase
{
    [HttpPost("AddStatistic/{questionId}")]
    public async Task<IActionResult> AddStatistic([FromRoute] uint? questionId)
    {
        try
        {
            await service.AddStatistic(questionId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("UpdateStatistic")]
    public async Task<IActionResult> UpdateStatistic([FromBody] UpdateStatisticDto updateStatisticDto)
    {
        try
        {
            await service.UpdateStatistic(updateStatisticDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetStatisticsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetStatisticsByTemplateId([FromRoute] uint? templateId)
    {
        try
        {
            var stats = await service.GetStatisticsByTemplateId(templateId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}