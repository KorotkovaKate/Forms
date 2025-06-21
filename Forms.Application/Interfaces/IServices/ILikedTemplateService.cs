using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ILikedTemplateService
{
    public Task<List<Template>> GetLikedTemplates(uint userId);
    public Task AddLikedTemplate(uint userId, uint templateId);
    public Task RemoveLikedTemplate(uint userId, uint templateId);
}