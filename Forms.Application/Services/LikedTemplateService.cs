using System.Net;
using Forms.Application.DTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class LikedTemplateService(ILikedTemplateRepository repository, ITemplateService templateService): ILikedTemplateService
{
    public async Task<Result<List<Template>>> GetLikedTemplates(uint? userId)
    {
        if (userId == null) {throw new ArgumentException("Incorrect user id");} //flvalid
        
        var templates = await repository.GetLikedTemplatesByUserId(userId.Value);
        if (templates.Count == 0) 
            return Result<List<Template>>.Failure("No Liked Templates found", HttpStatusCode.NotFound);
        
        return Result<List<Template>>.Success(templates);
    }

    public async Task<Result<bool>> AddLikedTemplate(LikedTemplateDto? likedTemplateDto)
    {
        if(likedTemplateDto.UserId == null) throw new ArgumentException("Incorrect user id"); //flvalid
        if(likedTemplateDto.TemplateId == null) throw new ArgumentException("Incorrect template id");
        
        var checkLikedTemplate = 
            await repository.GetLikedTemplate(likedTemplateDto.UserId.Value, likedTemplateDto.TemplateId.Value);

        if (checkLikedTemplate is not null)
            return Result<bool>.Failure("Template already liked", HttpStatusCode.BadRequest);
        
        var likedTemplate = LikedTemplateMapping.AddLikedTemplate(likedTemplateDto);
        await repository.AddLikedTemplate(likedTemplate);
        await templateService.IncreaseLikeNumber(likedTemplateDto.TemplateId);
        
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> RemoveLikedTemplate(LikedTemplateDto? likedTemplateDto)
    {
        if(likedTemplateDto.UserId == null) throw new ArgumentException("Incorrect user id"); //flvalid
        if(likedTemplateDto.TemplateId == null) throw new ArgumentException("Incorrect template id");
        
        var checkLikedTemplate = 
            await repository.GetLikedTemplate(likedTemplateDto.UserId.Value, likedTemplateDto.TemplateId.Value);

        if (checkLikedTemplate is null) 
            Result<bool>.Failure("Template already in not liked", HttpStatusCode.NotFound);
        
        var likedTemplate = LikedTemplateMapping.AddLikedTemplate(likedTemplateDto);
        await repository.RemoveLikedTemplate(likedTemplate);
        await templateService.DecreaseLikeNumber(likedTemplateDto.TemplateId);
        
        return Result<bool>.Success(true);
    }
}