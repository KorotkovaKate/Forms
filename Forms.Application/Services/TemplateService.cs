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
        if (templateId == null) {throw new ArgumentException("Inccorect id");}
        Template? template = await GetTemplateById(templateId);
        if (template == null) { throw new ArgumentException("Template not found"); }
        await repository.DeleteTemplate(template);
    }

    public async Task UpdateTemplate(UpdateTemplateDto  updateTemplateDto)
    {
        if (updateTemplateDto.TemplateId == null) {throw new ArgumentException("Invalid input data");}
        var template = TemplateMapping.UpdateTemplate(updateTemplateDto);
        await repository.UpdateTemplate(updateTemplateDto.TemplateId.Value, template);
    }

    public async Task<List<GetPublicTemplateDto>> GetAllPublicTemplates()
    {
        var allPublicTemplates = await repository.GetAllTemplates();
        if  (allPublicTemplates == null) { throw new Exception("No Public Templates found"); }
        return TemplateMapping.GetAllPublicTemplates(allPublicTemplates);
    }

    public async Task<List<GetAllTemplatesForAdminDto>> GetAllTemplates()
    {
        var templates = await repository.GetAllTemplates();
        if(templates == null) throw new Exception("Templates not found");
        return TemplateMapping.GetAllTemplatesForAdmin(templates);
    }

    public async Task<Template?> GetTemplateById(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect id");}
        return await repository.GetTemplateById(templateId.Value);
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
        Template? template = await GetTemplateById(templateId);
        if (template == null) { throw new ArgumentException("Template not found");}
        await repository.DecreaseLikeNumber(template);
    }
}