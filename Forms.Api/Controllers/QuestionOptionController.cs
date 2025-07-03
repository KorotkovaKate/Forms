using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("QuestionOption")]
public class QuestionOptionController(IQuestionOptionService service):ControllerBase
{
    [HttpGet("GetOptionsByQuestionId/{questionId}")]
    public async Task<IActionResult> GetOptionsByQuestionId(uint? questionId)
    {
        try
        {
            var options = await service.GetOptionsByQuestionId(questionId);
            return Ok(options);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetOptionById/{optionId}")]
    public async Task<IActionResult> GetOptionById(uint? optionId)
    {
        try
        {
            var option = await service.GetOptionById(optionId);
            return Ok(option);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("AddOption")]
    public async Task<IActionResult> AddOption([FromBody] AddOptionDto addOptionDto)
    {
        try
        {
            await service.AddOption(addOptionDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("DeleteOption/{optionId}")]
    public async Task<IActionResult> DeleteOption(uint? optionId)
    {
        try
        {
            await service.DeleteOption(optionId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}