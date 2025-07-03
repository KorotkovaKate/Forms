using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class LikedTemplateService(ILikedTemplateRepository repository, ITemplateService templateService): ILikedTemplateService
{
    public async Task<List<Template>> GetLikedTemplates(uint? userId)
    {
        if (userId == null) {throw new ArgumentException("Incorrect user id");}
        var templates = await repository.GetLikedTemplatesByUserId(userId.Value);
        if (templates == null) {throw new ArgumentException("Templates not found");}
        return templates;
    }

    public async Task AddLikedTemplate(LikedTemplateDto likedTemplateDto)
    {
        if(likedTemplateDto.UserId == null) throw new ArgumentException("Incorrect user id");
        if(likedTemplateDto.TemplateId == null) throw new ArgumentException("Incorrect template id");
        var checkLikedTemplate = await repository.GetLikedTemplate(likedTemplateDto.UserId.Value, likedTemplateDto.TemplateId.Value);

        if (checkLikedTemplate is not null) {throw new InvalidOperationException("Template already liked");}
        var likedTemplate = LikedTemplateMapping.AddLikedTemplate(likedTemplateDto);
        await repository.AddLikedTemplate(likedTemplate);
        await templateService.IncreaseLikeNumber(likedTemplateDto.TemplateId);
    }

    public async Task RemoveLikedTemplate(LikedTemplateDto likedTemplateDto)
    {
        if(likedTemplateDto.UserId == null) throw new ArgumentException("Incorrect user id");
        if(likedTemplateDto.TemplateId == null) throw new ArgumentException("Incorrect template id");
        var checkLikedTemplate = await repository.GetLikedTemplate(likedTemplateDto.UserId.Value, likedTemplateDto.TemplateId.Value);

        if (checkLikedTemplate is null) {throw new InvalidOperationException("Template not already liked");}
        var likedTemplate = LikedTemplateMapping.AddLikedTemplate(likedTemplateDto);
        await repository.RemoveLikedTemplate(likedTemplate);
        await templateService.DecreaseLikeNumber(likedTemplateDto.TemplateId);
    }
}