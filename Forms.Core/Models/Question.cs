using Forms.Core.Enums;

namespace Forms.Core.Models;

public class Question
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public Template Template { get; set; }
    public string Title { get; set; }
    public QuestionType Type { get; set; }
    public List<QuestionOption>? Options { get; set; }
}