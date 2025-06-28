using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IUserService
{
    public Task<User?> Authorize(AuthorizationDto authorizationDto);
    public Task Registrate(RegistrationDto  registrationDto);
    public Task<User?> GetUserById(uint? userId);
    public Task<List<User>> GetAllUsers();
}