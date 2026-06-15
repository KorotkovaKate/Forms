using Forms.Application.DTOs.QuestionDTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("QuestionOption")]
public class QuestionOptionController(IQuestionOptionService service): BaseApiController
{
    [HttpGet("GetOptionsByQuestionId/{questionId}")]
    public async Task<IActionResult> GetOptionsByQuestionId(uint? questionId)
    {
        var response = await service.GetOptionsByQuestionId(questionId);
        
        return HandleResult(response);
    }
    
    [HttpGet("GetOptionById/{optionId}")]
    public async Task<IActionResult> GetOptionById(uint? optionId)
    {
        var response = await service.GetOptionById(optionId);
        
        return HandleResult(response);
    }
    
    [HttpPost("AddOption")]
    public async Task<IActionResult> AddOption([FromBody] AddOptionDto addOptionDto)
    {
        var response = await service.AddOption(addOptionDto);
        
        return HandleResult(response);
    }
    
    [HttpDelete("DeleteOption/{optionId}")]
    public async Task<IActionResult> DeleteOption(uint? optionId)
    {
        var response = await service.DeleteOption(optionId);
        
        return HandleResult(response);
    }
    
}