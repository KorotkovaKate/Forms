using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class TemplateService(ITemplateRepository repository):ITemplateService
{
    public async Task CreateTemplate(CreateTemplateDto createTemplateDto)
    {
        if (createTemplateDto == null) { throw new ArgumentNullException(nameof(createTemplateDto));}
        if (string.IsNullOrWhiteSpace(createTemplateDto.Title) ||
            string.IsNullOrWhiteSpace(createTemplateDto.Description)
            )
        {
            throw new ArgumentException("Not all required field are filled in");
        }
        var template = TemplateMapping.CreateTemplate(createTemplateDto);
        await repository.CreateTemplate(template);
    }

    public async Task DeleteTemplate(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect id");}
        Template? template = await GetTemplateById(templateId);
        if (template == null) { throw new ArgumentException("Template not found"); }
        await repository.DeleteTemplate(template);
    }

    public async Task UpdateTemplate(UpdateTemplateDto  updateTemplateDto)
    {
        if (updateTemplateDto.TemplateId == null
            || string.IsNullOrWhiteSpace(updateTemplateDto.Title)
            || string.IsNullOrWhiteSpace(updateTemplateDto.Description)) {throw new ArgumentException("Invalid input data");}
        var template = TemplateMapping.UpdateTemplate(updateTemplateDto);
        await repository.UpdateTemplate(updateTemplateDto.TemplateId.Value, template);
    }

    public async Task<List<GetPublicTemplateDto>> GetAllPublicTemplates()
    {
        var allPublicTemplates = await repository.GetAllTemplates();
        ArgumentNullException.ThrowIfNull(allPublicTemplates, "Template list is null");
        if (!allPublicTemplates.Any()) throw new ArgumentException("Template not found");
        return TemplateMapping.GetAllPublicTemplates(allPublicTemplates);
    }

    public async Task<List<GetAllTemplatesForAdminDto>> GetAllTemplates()
    {
        var templates = await repository.GetAllTemplates();
        if(templates == null) throw new Exception("Template list cannot be null");
        if (!templates.Any()) throw new Exception("Template not found");
        return TemplateMapping.GetAllTemplatesForAdmin(templates);
    }

    public async Task<Template> GetTemplateById(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentNullException("Incorrect id");}
        var template = await repository.GetTemplateById(templateId.Value);
        ArgumentNullException.ThrowIfNull(template, "Template not found");
        return template;
    }

    public async Task IncreaseLikeNumber(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect id");}
        Template? template = await GetTemplateById(templateId);
        if (template == null) { throw new ArgumentException("Template not found");}
        await repository.IncreaseLikeNumber(template);
    }

    public async Task DecreaseLikeNumber(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect id");}
        Template template = await GetTemplateById(templateId);
        await repository.DecreaseLikeNumber(template);
    }
}