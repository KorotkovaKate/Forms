using System.Text;
using Forms.Application.DTOs;
using Forms.Application.Interfaces.ISecurity;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Mapping;
using Forms.Core.Enums;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using SHA3.Net;

namespace Forms.Application.Services;

public class UserService(IUserRepository repository, IPasswordHasher hasher): IUserServise
{
    public async Task<User?> Authorize(AutorizationDto autorizationDto)
    {
        var passwordHash = hasher.CalculateHash(autorizationDto.Password);
        if (autorizationDto.Email == null || autorizationDto.Password == null)
        {
            throw new ArgumentNullException("Еmail or password are empty");
        }
        var user = await repository.Authorize(autorizationDto.Email, passwordHash);
        if (user == null) { throw new Exception("Not found user"); }
        if (user.Status == UserStatus.Blocked) {throw new Exception("User is blocked"); }
        return user;
    }

    public async Task Register(RegistrationDto registrationDto)
    {
        var passwordHash = hasher.CalculateHash(registrationDto.Password);
        var user = UserMapping.MapRegistrationDtoToUser(registrationDto,  passwordHash);
        if (user == null) { throw new Exception("Empty user"); }
        await repository.Registrate(user);
    }

    public async Task<User?> GetUserById(uint userId)
    {
        if (userId == 0) { throw new ArgumentException("Inccorect id"); }
        var user = await repository.GetUserById(userId);
        return user;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await repository.GetAllUsers();
        return users;
    }
}