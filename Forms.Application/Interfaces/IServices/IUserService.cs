using Forms.Application.DTOs;
using Forms.Application.DTOs.UserDTOs;
using Forms.Core.Common;
using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IUserService
{
    public Task<Result<AuthorizationResponseDto>> Authorize(AuthorizationDto authorizationDto);
    public Task<Result<bool>> Registrate(RegistrationDto  registrationDto);
    public Task<Result<User>> GetUserById(uint? userId);
    public Task<Result<List<GetAllUsersDto>>> GetAllUsers();
    public Task<Result<bool>> BlockUser(uint? userId);
    public Task<Result<bool>> ActivateUser(uint? userId);
    public Task<Result<bool>> AddUserToAdmin(uint? userId);
    public Task<Result<bool>> RemoveUserFromAdmin(uint? userId);
}