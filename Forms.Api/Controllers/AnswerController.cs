using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Answer")]
public class AnswerController(IAnswerService service): ControllerBase
{
    [HttpPost("AddAnswer")]
    public async Task<IActionResult> AddAnswer([FromBody] Answer answer)
    {
        try
        {
            await service.AddAnswer(answer);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetAnswersByFormId/{formId}")]
    public async Task<IActionResult> GetAnswersByFormId([FromRoute] uint? formId)
    {
        try
        {
            var answers = await service.GetAnswersByFormId(formId);
            return Ok();
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
            var answers = await service.GetAnswerByQuestionId(questionId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}