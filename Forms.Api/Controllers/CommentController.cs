using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("Comment")]
public class CommentController(ICommentService service):ControllerBase
{
    [HttpPost("AddComment")]
    public async Task<IActionResult> AddComment([FromBody] Comment comment)
    {
        try
        {
            await service.AddComment(comment);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteComment/{commentId}")]
    public async Task<IActionResult> DeleteComment([FromRoute] uint? commentId)
    {
        try
        {
            await service.DeleteComment(commentId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCommentById/{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] uint? commentId)
    {
        try
        {
            var comment = await service.GetCommentById(commentId);
            return comment != null ? Ok() : NotFound("Comment not found");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("UpdateComment")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateMessageDto updateMessageDto)
    {
        try
        {
            await service.UpdateComment(updateMessageDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetCommentsByTemplateId/{templateId}")]
    public async Task<IActionResult> GetCommentsByTemplateId([FromRoute] uint? templateId)
    {
        try
        {
            var comments = await service.GetAllCommentsByTemplateId(templateId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}