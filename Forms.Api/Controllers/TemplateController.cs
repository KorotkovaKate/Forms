using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Template")]
public class TemplateController(ITemplateService service): ControllerBase
{
    [HttpPost("CreateTemplate")]
    public async Task<IActionResult> CreateTemplate([FromBody] CreateTemplateDto createTemplateDto)
    {
        try
        {
            await service.CreateTemplate(createTemplateDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("UpdateTemplate/{templateId}")]
    public async Task<IActionResult> UpdateTemplate([FromBody] UpdateTemplateDto  updateTemplateDto)
    {
        try
        {
            await service.UpdateTemplate(updateTemplateDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("DeleteTemplate/{templateId}")]
    public async Task<IActionResult> DeleteTemplate(uint? templateId)
    {
        try
        {
            await service.DeleteTemplate(templateId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAllTemplates")]
    public async Task<IActionResult> GetAllTemplates()
    {
        try
        {
            var templates = await service.GetAllTemplates();
            return Ok(templates);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAllPublicTemplates")]
    public async Task<IActionResult> GetAllPublicTemplates()
    {
        try
        {
            var publicTemplates = await service.GetAllPublicTemplates();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetTemplateById/{templateId}")]
    public async Task<IActionResult> GetTemplateById(uint? templateId)
    {
        try
        {
            var template = await service.GetTemplateById(templateId);
            return template != null ? Ok() : NotFound("Template not found");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch("IncreaseLikeNumber/{templateId}")]
    public async Task<IActionResult> IncreaseLikeNumber(uint? templateId)
    {
        try
        {
            await service.IncreaseLikeNumber(templateId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch("DecreaseLikeNumber/{templateId}")]
    public async Task<IActionResult> DecreaseLikeNumber(uint? templateId)
    {
        try
        {
            await service.DecreaseLikeNumber(templateId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}