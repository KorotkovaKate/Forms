using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface ITemplateRepository
{
    public Task CreateTemplate(Template template);
    public Task DeleteTemplate(Template template);
    public Task UpdateTemplate(uint templateId, Template template);
    public Task<List<Template>> GetAllPublicTemplates();
    public Task<List<Template>?> GetAllTemplates();
    public Task<Template?> GetTemplateById(uint templateId);
    public Task IncreaseLikeNumber(Template template);
    public Task DecreaseLikeNumber(Template template);
}