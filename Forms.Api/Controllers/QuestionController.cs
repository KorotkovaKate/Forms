using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Question")]
public class QuestionController(IQuestionService service):ControllerBase
{
    [HttpPost("AddQuestion")]
    public async Task<IActionResult> AddQuestion([FromBody] QuestionDto questionDto)
    {
        try
        {
            await service.AddQuestion(questionDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("DeleteQuestion/{questionId}")]
    public async Task<IActionResult> DeleteQuestion(uint? questionId)
    {
        try
        {
            await service.DeleteQuestion(questionId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetQuestionById/{questionId}")]
    public async Task<IActionResult> GetQuestionById(uint? questionId)
    {
        try
        {
            var question = await service.GetById(questionId);
            return Ok(question);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetQuestionsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetQuestionsByTemplateId(uint? templateId)
    {
        try
        {
            var questions = await service.GetQuestionsByTemplateId(templateId);
            return Ok(questions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}