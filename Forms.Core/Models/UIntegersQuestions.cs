using Forms.Core.Interfaces;

namespace Forms.Core.Models;

public class UIntegersQuestions: IQuestion
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public string Title { get; set; }
    
    public uint AnswerField { get; set; }
}