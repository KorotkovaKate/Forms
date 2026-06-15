using Forms.Application.DTOs.FormDTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Form")]
public class FormController(IFormService  formService): BaseApiController
{
    [HttpPost("CreateForm")]
    public async Task<IActionResult> CreateForm([FromBody] CreateFormDto createFormDto)
    {
        var response = await formService.CreateForm(createFormDto);
        
        return HandleResult(response);
    }

    [HttpGet("GetFormById/{formId}")]
    public async Task<IActionResult> GetFormById([FromRoute] uint? formId)
    {
        var response = await formService.GetFormById(formId);
        
        return HandleResult(response);
    }

    [HttpGet("GetFormsByUserId/{userId}")]
    public async Task<IActionResult> GetFormsByUserId([FromRoute] uint? userId)
    {
        var response = await formService.GetFormsByUserId(userId);
        
        return HandleResult(response);
    }

    [HttpGet("GetFormsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetFormsByTemplateId([FromRoute] uint? templateId)
    {
        var response = await formService.GetFormsByTemplateId(templateId);
        
        return HandleResult(response);
    }
}