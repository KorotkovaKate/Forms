using Forms.Application.DTOs.FormDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Form")]
public class FormController(IFormService  formService): ControllerBase
{
    [HttpPost("CreateForm")]
    public async Task<IActionResult> CreateForm([FromBody] CreateFormDto createFormDto)
    {
        try
        {
            await formService.CreateForm(createFormDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetFormById/{formId}")]
    public async Task<IActionResult> GetFormById([FromRoute] uint? formId)
    {
        try
        {
            var form = await formService.GetFormById(formId);
            return Ok(form);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetFormsByUserId/{userId}")]
    public async Task<IActionResult> GetFormsByUserId([FromRoute] uint? userId)
    {
        try
        {
            var forms = await formService.GetFormsByUserId(userId);
            return Ok(forms);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetFormsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetFormsByTemplateId([FromRoute] uint? templateId)
    {
        try
        {
            var forms = await formService.GetFormsByTemplateId(templateId);
            return Ok(forms);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}