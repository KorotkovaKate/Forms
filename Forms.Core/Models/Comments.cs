namespace Forms.Core.Models;

public class Comments
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public uint UserId { get; set; }
    public User  User { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}