using Forms.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController: ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result.Data == null) return NoContent();
            
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, new ProblemDetails
        {
            Status = result.StatusCode,
            Title = GetTitleForStatusCode(result.StatusCode),
            Detail = result.ErrorMessage,
            Instance = HttpContext.Request.Path
        });
    }

    private string GetTitleForStatusCode(int statusCode) => statusCode switch
    {
        400 => "Bad Request",
        401 => "Unauthorized",
        403 => "Forbidden",
        404 => "Not Found",
        409 => "Conflict",
        _ => "Server Error"
    };
}