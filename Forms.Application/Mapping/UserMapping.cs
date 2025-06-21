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
}