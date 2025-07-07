using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public static class UserMapping
{
    public static User MapRegistrationDtoToUser(RegistrationDto registrationDto, string passwordHash)
    {
        return new User
        {
            Email = registrationDto.Email,
            UserName = registrationDto.Username,
            PasswordHash = passwordHash,
            Role = registrationDto.Role
        };
    }

    public static List<GetAllUsersDto> GetAllUsers(List<User> users)
    {
        List<GetAllUsersDto> usersDto = new List<GetAllUsersDto>();
        
        foreach(var user in users) usersDto.Add(new GetAllUsersDto
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Role = user.Role,
            Status = user.Status
        });
        
        return usersDto;
    }

    public static AuthorizationResponseDto AuthorizationResponse(uint userId, string? token)
    {
        return new AuthorizationResponseDto
        {
            UserId = userId,
            Token = token
        };
    }
}