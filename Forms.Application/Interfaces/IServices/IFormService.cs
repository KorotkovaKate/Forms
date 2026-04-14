using Forms.Application.DTOs.FormDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IFormService
{
    public Task<Result<bool>> CreateForm(CreateFormDto? createFormDto);
    public Task<Result<Form>> GetFormById(uint? formId);
    public Task<Result<List<Form>>> GetFormsByUserId(uint? userId);
    public Task<Result<List<GetFormByTemplateIdDto>>> GetFormsByTemplateId(uint? templateId);
}