using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Statistic")]
public class StatisticController(IStatisticService  service): BaseApiController
{
    [HttpPost("AddStatistic/{questionId}")]
    public async Task<IActionResult> AddStatistic([FromRoute] uint? questionId)
    {
        var response = await service.AddStatistic(questionId);
        
        return HandleResult(response);
    }

    /*[HttpPut("UpdateStatistic")]
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
    }*/
    
    [HttpGet("GetStatisticsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetStatisticsByTemplateId([FromRoute] uint? templateId)
    {
        var response = await service.GetStatisticsByTemplateId(templateId);
        
        return HandleResult(response);
    }
}