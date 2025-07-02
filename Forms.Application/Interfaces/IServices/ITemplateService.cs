using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ITemplateService
{
    public Task CreateTemplate(CreateTemplateDto createTemplateDto);
    public Task DeleteTemplate(uint? templateId);
    public Task UpdateTemplate(UpdateTemplateDto  updateTemplateDto);
    public Task<List<Template>> GetAllPublicTemplates();
    public Task<List<GetAllTemplatesForAdminDto>> GetAllTemplates();
    public Task<Template?> GetTemplateById(uint? templateId);
    public Task IncreaseLikeNumber(uint? templateId);
    public Task DecreaseLikeNumber(uint? templateId);
}