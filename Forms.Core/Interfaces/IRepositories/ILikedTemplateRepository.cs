using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface ILikedTemplateRepository
{
    public Task<List<Template>> GetLikedTemplatesByUserId(uint userId);
    public Task AddLikedTemplate(LikedTemplate likedTemplate);
    public Task RemoveLikedTemplate(LikedTemplate likedTemplate);
}