using System.Text;
using Forms.Application.DTOs;
using Forms.Application.Interfaces.ISecurity;
using Forms.Application.Interfaces.IServices;
using Forms.Application.JwtTokens;
using Forms.Application.Mapping;
using Forms.Core.Enums;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using SHA3.Net;

namespace Forms.Application.Services;

public class UserService(IUserRepository repository, IPasswordHasher hasher, JwtService jwtService): IUserService
{
    public async Task<AuthorizationResponseDto> Authorize(AuthorizationDto authorizationDto)
    {
        if (string.IsNullOrWhiteSpace(authorizationDto.Email) || string.IsNullOrWhiteSpace(authorizationDto.Password))
        {
            throw new ArgumentException("Email or password are empty");
        }
        var passwordHash = hasher.CalculateHash(authorizationDto.Password);
        var user = await repository.Authorize(authorizationDto.Email, passwordHash);
        if (user == null) { throw new Exception("Not found user"); }
        else
        {
            if (user.Status == UserStatus.Blocked) {throw new Exception("User is blocked"); }

            string? token = jwtService.CreateToken(user);
            
            var response = UserMapping.AuthorizationResponse(user.Id, token);
            return response;
        }
    }

    public async Task Registrate(RegistrationDto registrationDto)
    {
        if (string.IsNullOrWhiteSpace(registrationDto.Email) || string.IsNullOrWhiteSpace(registrationDto.Password)
                                                             || string.IsNullOrWhiteSpace(registrationDto.Username))
        {
            throw new  ArgumentException("Email, password or username are empty");
        }
        var passwordHash = hasher.CalculateHash(registrationDto.Password);
        var user = UserMapping.MapRegistrationDtoToUser(registrationDto,  passwordHash);
        if (user == null) { throw new Exception("Empty user"); }
        await repository.Registrate(user);
    }

    public async Task<User> GetUserById(uint? userId)
    {
        if (userId == null) { throw new ArgumentException("Incorrect id"); }
        var user = await repository.GetUserById(userId.Value);
        if (user == null) { throw new ArgumentException("Not found user"); }
        return user;
    }

    public async Task<List<GetAllUsersDto>> GetAllUsers()
    {
        var users = await repository.GetAllUsers();
        if(!users.Any()) { throw new Exception("No users"); }

        var usersDto = UserMapping.GetAllUsers(users);
        return usersDto;
    }

    public async Task BlockUser(uint? userId)
    {
        if  (userId == null) { throw new ArgumentException("Incorrect id"); }
        var user = await GetUserById(userId);
        ArgumentNullException.ThrowIfNull(user, "Not found user");
        await repository.BlockUser(user); 
    }

    public async Task ActivateUser(uint? userId)
    {
        if  (userId == null) { throw new ArgumentException("Incorrect id"); }
        var user = await GetUserById(userId);
        ArgumentNullException.ThrowIfNull(user, "Not found user");
        await repository.ActivateUser(user);
    }
}