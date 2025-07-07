using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
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
            var response = await userService.Authorize(authorizationDto);
            
            return Ok(response);
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
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("BlockUser")]
    public async Task<IActionResult> BlockUser([FromBody] uint? userId)
    {
        try
        {
            await userService.BlockUser(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("ActivateUser")]
    public async Task<IActionResult> ActivateUser([FromBody] uint? userId)
    {
        try
        {
            await userService.ActivateUser(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}