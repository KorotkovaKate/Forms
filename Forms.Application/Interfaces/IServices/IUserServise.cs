using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IUserServise
{
    public Task<User?> Authorize(AutorizationDto autorizationDto);
    public Task Register(RegistrationDto  registrationDto);
    public Task<User?> GetUserById(uint userId);
    public Task<List<User>> GetAllUsers();
}