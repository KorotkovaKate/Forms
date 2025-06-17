using Forms.Core.Enums;

namespace Forms.Core.Models;

public class Template
{
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ThemeType Theme { get; set; }
    public string ImageUrl { get; set; }
    public List<string> Tags { get; set; }
    public uint TemplateCreatorId { get; set; }
    public User Creator { get; set; }
    public TemplateStatus Status { get; set; }
}