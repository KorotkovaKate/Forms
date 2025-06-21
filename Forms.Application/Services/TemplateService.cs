using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class TemplateService(ITemplateRepository repository):ITemplateService
{
    public async Task CreateTemplate(Template template)
    {
        if (template == null) { throw new ArgumentNullException(nameof(template));}
        if (string.IsNullOrWhiteSpace(template.Title) ||
            string.IsNullOrWhiteSpace(template.Description)
            || template.Theme == default
            || template.Status == default)
        {
            throw new ArgumentException("Not all required field are filled in");
        }

        await repository.CreateTemplate(template);
    }

    public async Task DeleteTemplate(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Inccorect id");}
        Template? template = await GetTemplateById(templateId);
        if (template == null) { throw new ArgumentException("Template not found"); }
        await repository.DeleteTemplate(template);
    }

    public async Task UpdateTemplate(uint templateId, Template template)
    {
        if (template == null) {throw new ArgumentException("Invalid input data");}
        await repository.UpdateTemplate(templateId, template);
    }

    public async Task<List<Template>> GetAllPublicTemplates()
    {
        return await repository.GetAllPublicTemplates();
    }

    public async Task<List<Template>> GetAllTemplates()
    {
        return await repository.GetAllTemplates();
    }

    public async Task<Template?> GetTemplateById(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect id");}
        return await repository.GetTemplateById(templateId.Value);
    }
}