using Forms.Core.Interfaces;

namespace Forms.Core.Models;

public class CheckboxesQuestions: IQuestion
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public string Title { get; set; }
    
    public List<string> AnswerField { get; set; }
}