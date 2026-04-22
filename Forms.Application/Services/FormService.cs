using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Forms.Application.DTOs.FormDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Common;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class FormService(IFormRepository repository): IFormService 
{
    public async Task<Result<bool>> CreateForm(CreateFormDto? createFormDto)
    {
        if (createFormDto == null || createFormDto.SubmitterId == null || createFormDto.TemplateId == null
            || createFormDto.Answers == null) {throw new ArgumentException("Invalid form");} //flvalid
        
        var form = FormMapping.CreateForm(createFormDto);
        await repository.CreateForm(form);
        
        return Result<bool>.Success(true);
    }

    public async Task<Result<Form>> GetFormById(uint? formId)
    {
        if (formId == null)  return Result<Form>.Failure("Invalid form id", HttpStatusCode.BadRequest);
        
        var form = await repository.GetFormById(formId.Value);
        if (form == null) return Result<Form>.Failure("Form not found", HttpStatusCode.NotFound);
        
        return Result<Form>.Success(form);
    }

    public async Task<Result<List<Form>>> GetFormsByUserId(uint? userId)
    {
        if (userId == null) 
            return Result<List<Form>>.Failure("Invalid user id", HttpStatusCode.BadRequest);
        
        var forms = await repository.GetFormsByUserId(userId.Value);
        if (forms.Count == 0)
            return Result<List<Form>>.Failure("Form not found", HttpStatusCode.NotFound);
        
        return Result<List<Form>>.Success(forms);
    }

    public async Task<Result<List<GetFormByTemplateIdDto>>> GetFormsByTemplateId(uint? templateId)
    {
        if (templateId == null)
            return Result<List<GetFormByTemplateIdDto>>
                .Failure("Invalid template id", HttpStatusCode.BadRequest);
        
        var  forms = await repository.GetFormsByTemplateId(templateId.Value);
        if (forms.Count == 0)
            return Result<List<GetFormByTemplateIdDto>>
                .Failure("Form not found", HttpStatusCode.NotFound);
        
        var  allForms = FormMapping.GetFormByTemplateId(forms);
        return Result<List<GetFormByTemplateIdDto>>.Success(allForms);
    }
}