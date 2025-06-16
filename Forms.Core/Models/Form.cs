namespace Forms.Core.Models;

public class Form
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; } 
    public uint Submitter { get; set; }
    public DateTime SubmittedTime { get; set; } = DateTime.Now;
}