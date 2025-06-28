using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("LikedTemplate")]
public class LikedTemplateController(ILikedTemplateService service):ControllerBase
{
    [HttpGet("GetLikedTemplates/{userId}")]
    public async Task<IActionResult> GetLikedTemplates([FromRoute] uint? userId)
    {
        try
        {
            var templates = await service.GetLikedTemplates(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("AddLikedTemplate")]
    public async Task<IActionResult> AddLikedTemplate([FromBody] LikedTemplateDto dto)
    {
        try
        {
            await service.AddLikedTemplate(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("RemoveLikedTemplate")]
    public async Task<IActionResult> RemoveLikedTemplate([FromBody] LikedTemplateDto dto)
    {
        try
        {
            await service.RemoveLikedTemplate(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}