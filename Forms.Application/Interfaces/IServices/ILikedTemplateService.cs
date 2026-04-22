using System.Collections.Generic;
using System.Threading.Tasks;
using Forms.Application.DTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface ILikedTemplateService
{
    public Task<Result<List<Template>>> GetLikedTemplates(uint? userId);
    public Task<Result<bool>> AddLikedTemplate(LikedTemplateDto? likedTemplateDto);
    public Task<Result<bool>> RemoveLikedTemplate(LikedTemplateDto? likedTemplateDto);
}