using Forms.Core.Enums;

namespace Forms.Application.DTOs;

public class RegistrationDto
{
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    
    public UserRole Role { get; set; } = UserRole.User;
}