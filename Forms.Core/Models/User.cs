using Forms.Core.Enums;

namespace Forms.Core.Models;

public class User
{
    public uint Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public UserStatus Status { get; set; } = UserStatus.Active;
    public List<Template> Templates { get; set; }
    public List<Form> Forms { get; set; }
    public List<LikedTemplate> LikedTemplates { get; set; } 
    public List<Comment> Comments { get; set; }
}