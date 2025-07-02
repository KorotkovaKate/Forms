using Forms.Application.DTOs.FormDTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IFormService
{
    public Task CreateForm(CreateFormDto createFormDto);
    public Task<Form?> GetFormById(uint? formId);
    public Task<List<Form>> GetFormsByUserId(uint? userId);
    public Task<List<Form>> GetFormsByTemplateId(uint? templateId);
}