using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IFormRepository
{
    public Task CreateForm(Form form);
    public Task<Form?> GetFormById(uint formId);
    public Task<List<Form>> GetFormsByUserId(uint userId);
    public Task<List<Form>> GetFormsByTemplateId(uint templateId);
}