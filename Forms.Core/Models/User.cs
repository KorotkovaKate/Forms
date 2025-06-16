using Forms.Core.Enums;

namespace Forms.Core.Models;

public class User
{
    public uint Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    public List<Template> LikedTemplates { get; set; } 
}