using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface ILikedTemplateRepository
{
    public Task<List<Template>> GetLikedTemplatesByUserId(uint userId);
    public Task AddLikedTemplate(uint userId, uint templateId);
    public Task RemoveLikedTemplate(uint userId, uint templateId);
}