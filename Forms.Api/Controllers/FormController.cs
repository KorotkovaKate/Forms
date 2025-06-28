using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Form")]
public class FormController(IFormService  formService): ControllerBase
{
    [HttpPost("CreateForm")]
    public async Task<IActionResult> CreateForm([FromBody] Form form)
    {
        try
        {
            await formService.CreateForm(form);
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
            return form != null ? Ok() : NotFound("Form not found");
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
            return Ok();
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
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}