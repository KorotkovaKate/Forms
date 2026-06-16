using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Question")]
public class QuestionController(IQuestionService service): BaseApiController
{
    [HttpPost("AddQuestion")]
    public async Task<IActionResult> AddQuestion([FromBody] QuestionDto questionDto)
    {
        var response = await service.AddQuestion(questionDto);
        
        return HandleResult(response);
    }
    
    [HttpDelete("DeleteQuestion/{questionId}")]
    public async Task<IActionResult> DeleteQuestion(uint? questionId)
    {
        var response = await service.DeleteQuestion(questionId);
        
        return HandleResult(response);
    }
    
    [HttpGet("GetQuestionById/{questionId}")]
    public async Task<IActionResult> GetQuestionById(uint? questionId)
    {
        var response = await service.GetById(questionId);

        return HandleResult(response);
    }
    
    [HttpGet("GetQuestionsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetQuestionsByTemplateId(uint? templateId)
    {
        var response = await service.GetQuestionsByTemplateId(templateId);
        
        return HandleResult(response);
    }
}