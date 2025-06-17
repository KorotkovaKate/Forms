namespace Forms.Core.Models;

public class Form
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public Template Template { get; set; }
    public uint SubmitterId { get; set; }
    public User Submitter { get; set; }
    public DateTime SubmittedTime { get; set; } = DateTime.Now;
    public List<Answer> Answers { get; set; }
}