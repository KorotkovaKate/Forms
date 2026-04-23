using System;
using System.Threading.Tasks;
using Forms.Application.DTOs.AnswerDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Answer")]
public class AnswerController(IAnswerService service): BaseApiController
{
    [HttpGet("GetAnswersByFormId/{formId}")]
    public async Task<IActionResult> GetAnswersByFormId([FromRoute] uint? formId)
    {
        var response = await service.GetAnswersByFormId(formId);

        return HandleResult(response);
    }

    [HttpGet("GetAnswersByQuestionId/{questionId}")]
    public async Task<IActionResult> GetAnswersByQuestionId([FromRoute] uint? questionId)
    {
        var response = await service.GetAnswersByQuestionId(questionId);
        
        return HandleResult(response);
    }
}