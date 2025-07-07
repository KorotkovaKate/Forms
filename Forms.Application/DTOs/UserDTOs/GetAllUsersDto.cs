using Forms.Core.Enums;

namespace Forms.Application.DTOs;

public class GetAllUsersDto
{
    public uint UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
}