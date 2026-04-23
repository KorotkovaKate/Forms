using System;
using System.Threading.Tasks;
using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("LikedTemplate")]
public class LikedTemplateController(ILikedTemplateService service): BaseApiController
{
    [HttpGet("GetLikedTemplates/{userId}")]
    public async Task<IActionResult> GetLikedTemplates([FromRoute] uint? userId)
    {
        var response = await service.GetLikedTemplates(userId);
        
        return HandleResult(response);
    }

    [HttpPost("AddLikedTemplate")]
    public async Task<IActionResult> AddLikedTemplate([FromBody] LikedTemplateDto dto)
    {
        var response = await service.AddLikedTemplate(dto);
        
        return HandleResult(response);
    }

    [HttpPost("RemoveLikedTemplate")]
    public async Task<IActionResult> RemoveLikedTemplate([FromBody] LikedTemplateDto dto)
    {
        var response = await service.RemoveLikedTemplate(dto);
        
        return HandleResult(response);
    }
}