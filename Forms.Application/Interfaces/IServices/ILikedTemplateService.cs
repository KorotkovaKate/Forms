using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ILikedTemplateService
{
    public Task<List<Template>> GetLikedTemplates(uint? userId);
    public Task AddLikedTemplate(LikedTemplateDto likedTemplateDto);
    public Task RemoveLikedTemplate(LikedTemplateDto likedTemplateDto);
}