namespace Forms.Core.Models;

public class Comment
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public Template Template { get; set; }
    public uint UserId { get; set; }
    public User  User { get; set; }
    public string Text { get; set; }
    public DateTime PublishTime { get; set; } = DateTime.Now;
}