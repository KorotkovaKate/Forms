using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Forms.Application.Common.Mapping;
using Forms.Application.DTOs;
using Forms.Application.DTOs.TemplateDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class TemplateService(ITemplateRepository repository):ITemplateService
{
    public async Task<Result<bool>> CreateTemplate(CreateTemplateDto? createTemplateDto)
    {
        if (createTemplateDto == null)
            return Result<bool>
                .Failure("Empty template is error", HttpStatusCode.BadRequest);
        
        if (string.IsNullOrWhiteSpace(createTemplateDto.Title) ||
            string.IsNullOrWhiteSpace(createTemplateDto.Description) || 
            string.IsNullOrWhiteSpace(createTemplateDto.Theme))
        {
            return Result<bool>.Failure("Bad data in response", HttpStatusCode.BadRequest);
        }
        
        var template = TemplateMapping.CreateTemplate(createTemplateDto);
        await repository.CreateTemplate(template);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteTemplate(uint? templateId)
    {
        if (templateId == null) 
            return Result<bool>.Failure("Id can't be null", HttpStatusCode.BadRequest);
        
        var templateResult = await GetTemplateById(templateId);
        if (!templateResult.IsSuccess) 
            return Result<bool>
                .Failure(templateResult.ErrorMessage, (HttpStatusCode)templateResult.StatusCode);

        var template = templateResult.Data;
        await repository.DeleteTemplate(template);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> UpdateTemplate(UpdateTemplateDto?  updateTemplateDto)
    {
        if (updateTemplateDto.TemplateId == null
            || string.IsNullOrWhiteSpace(updateTemplateDto.Title)
            || string.IsNullOrWhiteSpace(updateTemplateDto.Description))
            return Result<bool>.Failure("Empty template is error", HttpStatusCode.BadRequest);
        
        var template = TemplateMapping.UpdateTemplate(updateTemplateDto);
        await repository.UpdateTemplate(updateTemplateDto.TemplateId.Value, template);
        return Result<bool>.Success(true);
    }

    public async Task<Result<List<GetPublicTemplateDto>>> GetAllPublicTemplates()
    {
        var allPublicTemplates = await repository.GetAllTemplates();
        if(!allPublicTemplates.Any()) 
            return Result<List<GetPublicTemplateDto>>
                .Failure("No templates", HttpStatusCode.NotFound);
        
        var response = TemplateMapping.GetAllPublicTemplates(allPublicTemplates);
        return Result<List<GetPublicTemplateDto>>.Success(response);
    }

    
    public async Task<Result<List<GetAllTemplatesDto>>> GetAllTemplates()
    {
        var templates = await repository.GetAllTemplates();
        if (templates.Count == 0)
            return Result<List<GetAllTemplatesDto>>
                .Failure("No templates", HttpStatusCode.NotFound);
        
        var response = TemplateMapping.GetAllTemplatesForAdmin(templates);
        return Result<List<GetAllTemplatesDto>>.Success(response);
    }

    public async Task<Result<List<GetAllTemplatesDto>>> GetTemplatesByUserId(uint? userId)
    {
        if (userId == null) 
            Result<List<GetAllTemplatesDto>>
                .Failure("Id can't be null", HttpStatusCode.BadRequest);
        
        var templates = await repository.GetTemplatesByUserId(userId);
        if(templates.Count == 0) Result<List<GetAllTemplatesDto>>.Failure("No templates", HttpStatusCode.NotFound);
        
        var response = TemplateMapping.GetAllTemplatesForAdmin(templates);
        return Result<List<GetAllTemplatesDto>>.Success(response);
    }

    public async Task<Result<Template>> GetTemplateById(uint? templateId)
    {
        if (templateId == null) 
            return Result<Template>
                .Failure("Id can't be null", HttpStatusCode.BadRequest);
        
        var template = await repository.GetTemplateById(templateId.Value);
        if (template == null)
            return Result<Template>
                .Failure("Template not found", HttpStatusCode.NotFound);
        
        return Result<Template>.Success(template);
    }

    public async Task<Result<bool>> IncreaseLikeNumber(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect id");}
        var templateResult = await GetTemplateById(templateId);
        
        if (!templateResult.IsSuccess) 
            return Result<bool>.Failure(templateResult.ErrorMessage, HttpStatusCode.BadRequest);
        
        var template = templateResult.Data;
        await repository.IncreaseLikeNumber(template);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DecreaseLikeNumber(uint? templateId)
    {
        if (templateId == null) 
            return Result<bool>
                .Failure("Incorrect id", HttpStatusCode.BadRequest);
        
        var templateResult = await GetTemplateById(templateId);
        if (!templateResult.IsSuccess)
            return Result<bool>.Failure(templateResult.ErrorMessage, HttpStatusCode.BadRequest);
        
        var template = templateResult.Data;
        await repository.DecreaseLikeNumber(template);
        return Result<bool>.Success(true);
    }
}