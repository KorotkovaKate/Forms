using Forms.Application.Interfaces.IServices;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class FormService(IFormRepository repository): IFormService 
{
    public async Task CreateForm(Form form)
    {
        if (form == null || form.Submitter == null || form.Template == null)
        {
            throw new ArgumentException("Invalid form");
        }
        await repository.CreateForm(form);
    }

    public async Task<Form?> GetFormById(uint? formId)
    {
        if (formId == null) {throw new ArgumentException("Incorrect form id");}
        return await repository.GetFormById(formId.Value);
    }

    public async Task<List<Form>> GetFormsByUserId(uint? userId)
    {
        if (userId == null) {throw new ArgumentException("Incorrect user id");}
        return await repository.GetFormsByUserId(userId.Value);
    }

    public async Task<List<Form>> GetFormsByTemplateId(uint? templateId)
    {
        if (templateId == null) {throw new ArgumentException("Incorrect template id");}
        return await repository.GetFormsByUserId(templateId.Value);
    }
}