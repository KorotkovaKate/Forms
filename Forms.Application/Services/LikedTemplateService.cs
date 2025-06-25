using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class LikedTemplateService(ILikedTemplateRepository repository, ITemplateService templateService): ILikedTemplateService
{
    public async Task<List<Template>> GetLikedTemplates(uint? userId)
    {
        if (userId == null) {throw new ArgumentException("Incorrect user id");}
        return await repository.GetLikedTemplatesByUserId(userId.Value);
    }

    public async Task AddLikedTemplate(LikedTemplateDto likedTemplateDto)
    {
        var checkLikedTemplate = await repository.GetLikedTemplate(likedTemplateDto.UserId, likedTemplateDto.TemplateId);

        if (checkLikedTemplate is not null) {throw new InvalidOperationException("Template already liked");}
        var likedTemplate = new LikedTemplate
        {
            UserId = likedTemplateDto.UserId,
            TemplateId = likedTemplateDto.TemplateId
        };
        await repository.AddLikedTemplate(likedTemplate);
        await templateService.IncreaseLikeNumber(likedTemplateDto.TemplateId);
    }

    public async Task RemoveLikedTemplate(LikedTemplateDto likedTemplateDto)
    {
        var checkLikedTemplate = await repository.GetLikedTemplate(likedTemplateDto.UserId, likedTemplateDto.TemplateId);

        if (checkLikedTemplate is null) {throw new InvalidOperationException("Template not already liked");}
        var likedTemplate = new LikedTemplate
        {
            UserId = likedTemplateDto.UserId,
            TemplateId = likedTemplateDto.TemplateId
        };
        await repository.RemoveLikedTemplate(likedTemplate);
        await templateService.DecreaseLikeNumber(likedTemplateDto.TemplateId);
    }
}