using Forms.Application.DTOs;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IUserService
{
    public Task<string> Authorize(AuthorizationDto authorizationDto);
    public Task Registrate(RegistrationDto  registrationDto);
    public Task<User> GetUserById(uint? userId);
    public Task<List<User>> GetAllUsers();
    public Task BlockUser(uint? userId);
    public Task ActivateUser(uint? userId);
}