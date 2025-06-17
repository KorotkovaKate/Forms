namespace Forms.Core.Models;

public class Answer
{
    public uint Id { get; set; }
    public uint FormId { get; set; }
    public Form Form { get; set; }
    public uint QuestionId { get; set; }
    public Question Question { get; set; }
    public string Value { get; set; }
}