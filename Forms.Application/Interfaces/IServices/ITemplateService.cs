using Forms.Application.DTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ITemplateService
{
    public Task<Result<bool>> CreateTemplate(CreateTemplateDto? createTemplateDto);
    public Task<Result<bool>> DeleteTemplate(uint? templateId);
    public Task<Result<bool>> UpdateTemplate(UpdateTemplateDto?  updateTemplateDto);
    public Task<Result<List<GetPublicTemplateDto>>> GetAllPublicTemplates();
    public Task<Result<List<GetAllTemplatesDto>>> GetAllTemplates();
    public Task<Result<List<GetAllTemplatesDto>>> GetTemplatesByUserId(uint? userId);
    public Task<Result<Template>> GetTemplateById(uint? templateId);
    public Task<Result<bool>> IncreaseLikeNumber(uint? templateId);
    public Task<Result<bool>> DecreaseLikeNumber(uint? templateId);
}