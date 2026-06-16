using Forms.Application.DTOs;
using Forms.Application.DTOs.UserDTOs;
using Forms.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;

[ApiController]
[Route("User")]
public class UserController(IUserService userService) : BaseApiController
{
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await userService.GetAllUsers();

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

        return HandleResult(response);
    }

    [HttpGet("GetUserById/{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] uint? userId)
    {
        var response = await userService.GetUserById(userId);

        return HandleResult(response);
    }

    [HttpPost("BlockUser")]
    public async Task<IActionResult> BlockUser([FromBody] uint? userId)
    {
        var response = await userService.BlockUser(userId);

        return HandleResult(response);
    }

    [HttpPost("ActivateUser")]
    public async Task<IActionResult> ActivateUser([FromBody] uint? userId)
    {
        var response = await userService.ActivateUser(userId);

        return HandleResult(response);
    }

    [HttpPost("AddUserToAdmin")]
    public async Task<IActionResult> AddUserToAdmin([FromBody] uint? userId)
    {
        var response = await userService.AddUserToAdmin(userId);
        
        return HandleResult(response);
    }

    [HttpPost("RemoveUserFromAdmin")]
    public async Task<IActionResult> RemoveUserFromAdmin([FromBody] uint? userId)
    {
        var response = await userService.RemoveUserFromAdmin(userId);
        
        return HandleResult(response);
    }
}