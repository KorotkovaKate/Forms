using Forms.Application.DTOs.AnswerDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Answer")]
public class AnswerController(IAnswerService service): ControllerBase
{
    [HttpGet("GetAnswersByFormId/{formId}")]
    public async Task<IActionResult> GetAnswersByFormId([FromRoute] uint? formId)
    {
        try
        {
            var answers = await service.GetAnswersByFormId(formId);
            return Ok(answers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAnswersByQuestionId/{questionId}")]
    public async Task<IActionResult> GetAnswersByQuestionId([FromRoute] uint? questionId)
    {
        try
        {
            var answers = await service.GetAnswersByQuestionId(questionId);
            return Ok(answers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}