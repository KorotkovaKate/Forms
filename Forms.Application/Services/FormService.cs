using Forms.Application.DTOs.FormDTOs;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class FormService(IFormRepository repository): IFormService 
{
    public async Task CreateForm(CreateFormDto createFormDto)
    {
        if (createFormDto == null || createFormDto.SubmitterId == null || createFormDto.TemplateId == null
            || createFormDto.Answers == null) throw new ArgumentException("Invalid form");
        //прописать проверку answerов, чтобы какой-то можеьт быть нал
        var form = FormMapping.CreateForm(createFormDto);
        await repository.CreateForm(form);
    }

    public async Task<Form> GetFormById(uint? formId)
    {
        if (formId == null) {throw new ArgumentException("Incorrect form id");}
        var form = await repository.GetFormById(formId.Value);
        if (form == null) throw new ArgumentException("Form not found");
        return form;
    }

    public async Task<List<Form>> GetFormsByUserId(uint? userId)
    {
        if (userId == null) {throw new ArgumentException("Incorrect user id");}
        var forms = await repository.GetFormsByUserId(userId.Value);
        if (forms == null) throw new ArgumentException("Forms not found");
        return forms;
    }

    public async Task<List<Form>> GetFormsByTemplateId(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect template id");}
        var  forms = await repository.GetFormsByTemplateId(templateId.Value);
        if (forms == null) throw new ArgumentException("Forms not found");
        return forms;
    }
}