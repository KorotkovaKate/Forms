using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Mapping;

public class LikedTemplateMapping
{
    public static LikedTemplate AddLikedTemplate(LikedTemplateDto likedTemplateDto)
    {
        return new LikedTemplate
        {
            UserId = likedTemplateDto.UserId.Value,
            TemplateId = likedTemplateDto.TemplateId.Value
        };
    }
}