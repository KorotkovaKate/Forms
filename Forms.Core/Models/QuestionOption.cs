namespace Forms.Core.Models;

public class QuestionOption
{
    public uint Id { get; set; }
    public uint QuestionId { get; set; }
    public Question Question { get; set; }
    public string Value { get; set; }
}