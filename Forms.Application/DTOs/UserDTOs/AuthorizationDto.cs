using Forms.Core.Enums;

namespace Forms.Application.DTOs;

public class AuthorizationDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}