using System;
using System.Threading.Tasks;
using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;
[ApiController]
[Route("User")]
public class UserController(IUserService  userService): BaseApiController
{
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var response  = await userService.GetAllUsers();

        return HandleResult(response);
    }
    
    [HttpPost("Authorize")]
    public async Task<IActionResult> Authorize([FromBody] AuthorizationDto authorizationDto)
    { 
        var response = await userService.Authorize(authorizationDto);
        
        return HandleResult(response);
    }
    
    [HttpPost("Registrate")]
    public async Task<IActionResult> Registrate([FromBody] RegistrationDto registrationDto)
    {
        
        var response = await userService.Registrate(registrationDto);
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