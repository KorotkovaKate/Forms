using Forms.Application.DTOs;
using Forms.Application.DTOs.TemplateDTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Template")]
public class TemplateController(ITemplateService service): BaseApiController
{
    [HttpPost("CreateTemplate")]
    public async Task<IActionResult> CreateTemplate([FromBody] CreateTemplateDto createTemplateDto)
    { 
        var response = await service.CreateTemplate(createTemplateDto); 
        
        return HandleResult(response);
    }
    
    [HttpPut("UpdateTemplate/{templateId}")]
    public async Task<IActionResult> UpdateTemplate([FromBody] UpdateTemplateDto  updateTemplateDto)
    {
            var response = await service.UpdateTemplate(updateTemplateDto);
           
            return HandleResult(response);
    }
    
    [HttpDelete("DeleteTemplate/{templateId}")]
    public async Task<IActionResult> DeleteTemplate(uint? templateId)
    {
        var response = await service.DeleteTemplate(templateId);
            
        return HandleResult(response);
    }
    
    [HttpGet("GetAllTemplates")]
    public async Task<IActionResult> GetAllTemplates()
    {
        var response = await service.GetAllTemplates();
            
        return HandleResult(response);
    }
    [HttpGet("GetAllPublicTemplates")]
    public async Task<IActionResult> GetAllPublicTemplates()
    { 
        var response = await service.GetAllPublicTemplates();
        
        return HandleResult(response);
    }
    
    [HttpGet("GetTemplateById/{templateId}")]
    public async Task<IActionResult> GetTemplateById(uint? templateId)
    { 
        var response = await service.GetTemplateById(templateId);
        
        return HandleResult(response);
    }

    [HttpGet("GetTemplatesByUserId/{userId}")]
    public async Task<IActionResult> GetTemplatesByUserId(uint? userId)
    {
        var response = await service.GetTemplatesByUserId(userId);
        
        return HandleResult(response);
    }
        
    [HttpPatch("IncreaseLikeNumber/{templateId}")]
    public async Task<IActionResult> IncreaseLikeNumber(uint? templateId)
    {
            var response = await service.IncreaseLikeNumber(templateId);
            
            return HandleResult(response);
    }
    
    [HttpPatch("DecreaseLikeNumber/{templateId}")]
    public async Task<IActionResult> DecreaseLikeNumber(uint? templateId)
    { 
        var response = await service.DecreaseLikeNumber(templateId); 
        
        return HandleResult(response);
    }

    [HttpGet("GetTemplateThemes")]
    public async Task<IActionResult> GetTemplateThemes()
    {
        var response = service.GetTemplateThemes();
        
        return HandleResult(response);
    }
}