using Forms.Application.DTOs;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Comment")]
public class CommentController(ICommentService service): BaseApiController
{
    [HttpPost("AddComment")]
    public async Task<IActionResult> AddComment([FromBody] AddCommentDto addCommentDto)
    {
        var response = await service.AddComment(addCommentDto);
        
        return HandleResult(response);
    }

    [HttpDelete("DeleteComment/{commentId}")]
    public async Task<IActionResult> DeleteComment([FromRoute] uint? commentId)
    {
        var response = await service.DeleteComment(commentId);
        
        return HandleResult(response);
    }

    [HttpGet("GetCommentById/{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] uint? commentId)
    {
        var response = await service.GetCommentById(commentId);
        
        return HandleResult(response);
    }

    [HttpPut("UpdateComment")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateCommentDto)
    {
        var response = await service.UpdateComment(updateCommentDto);
        
        return HandleResult(response);
    }

    [HttpGet("GetCommentsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetCommentsByTemplateId([FromRoute] uint? templateId)
    {
        var response = await service.GetAllCommentsByTemplateId(templateId);
        
        return HandleResult(response);
    }
}