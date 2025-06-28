using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("User")]
public class UserController(IUserService  userService): ControllerBase
{
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("Authorize")]
    public async Task<IActionResult> Authorize([FromBody] AuthorizationDto authorizationDto)
    {
        try
        {
            var user = await userService.Authorize(authorizationDto);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Registrate")]
    public async Task<IActionResult> Registrate([FromBody] RegistrationDto registrationDto)
    {
        try
        {
            await userService.Registrate(registrationDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("GetUserById/{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] uint? userId)
    {
        try
        {
            var user = await userService.GetUserById(userId);
            return user != null ? Ok() : NotFound("User not found");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}