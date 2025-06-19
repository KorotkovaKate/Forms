namespace Forms.Core.Models;

public class Statistic
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public Template Template { get; set; }
    public uint QuestionId { get; set; }
    public Question Question { get; set; }
    public string MostCommonAnswer { get; set; }
    public int AnswerFrequencyInPercent { get; set; }
}