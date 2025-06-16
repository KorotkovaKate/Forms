namespace Forms.Core.Interfaces;

public interface IQuestion
{
    public uint Id { get; set; }
    public uint TemplateId { get; set; }
    public string Title { get; set; }
}