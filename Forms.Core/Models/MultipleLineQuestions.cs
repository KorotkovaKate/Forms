using Forms.Core.Interfaces;

namespace Forms.Core.Models;

public class MultipleLineQuestions: IQuestion
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public string Title { get; set; }
    
    public string AnswerField { get; set; }
}