using System.Net;
using Forms.Application.Common.Mapping;
using Forms.Application.Common.Validators.UserValidators;
using Forms.Application.DTOs;
using Forms.Application.DTOs.UserDTOs;
using Forms.Application.Interfaces.ISecurity;
using Forms.Application.Interfaces.IServices;
using Forms.Core.Common;
using Forms.Core.Enums;
using Forms.Core.Exceptions;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;

namespace Forms.Application.Services;

public class UserService(IUserRepository repository, IPasswordHasher hasher, IJwtService jwtService): IUserService
{
    public async Task<Result<AuthorizationResponseDto>> Authorize(AuthorizationDto authorizationDto)
    {
        var validator = new AuthorizationDtoValidator();
        var validationResult = await validator.ValidateAsync(authorizationDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.ToDictionary());
        
        var passwordHash = hasher.CalculateHash(authorizationDto.Password);
        var user = await repository.Authorize(authorizationDto.Email, passwordHash);
        if (user == null)
        {
            return Result<AuthorizationResponseDto>
                .Failure("Authorization is not success", HttpStatusCode.Unauthorized); ;
        }
        
        if (user.Status == UserStatus.Blocked) 
            return Result<AuthorizationResponseDto>.Failure("User is blocked", HttpStatusCode.Forbidden);

        string token = jwtService.CreateToken(user);
            
        var response = UserMapping.AuthorizationResponse(user.Id, token);
        return Result<AuthorizationResponseDto>.Success(response);
    }

    public async Task<Result<bool>> Registrate(RegistrationDto registrationDto)
    {
        if (string.IsNullOrWhiteSpace(registrationDto.Email) || string.IsNullOrWhiteSpace(registrationDto.Password)
                                                             || string.IsNullOrWhiteSpace(registrationDto.Username))
        {
            throw new  ArgumentException("Email, password or username are empty");
        }
        var passwordHash = hasher.CalculateHash(registrationDto.Password);
        var user = UserMapping.MapRegistrationDtoToUser(registrationDto,  passwordHash);
        if (user == null) return Result<bool>.Failure("User is null for registration", HttpStatusCode.BadRequest);
        await repository.Registrate(user);
        return Result<bool>.Success(true);
    }

    public async Task<Result<User>> GetUserById(uint? userId)
    {
        if (userId == null) return Result<User>.Failure("Incorrect user id", HttpStatusCode.BadRequest);
        
        var user = await repository.GetUserById(userId.Value);
        if (user == null) return Result<User>.Failure("User not found", HttpStatusCode.NotFound);
        
        return Result<User>.Success(user);
    }

    public async Task<Result<List<GetAllUsersDto>>> GetAllUsers()
    {
        var users = await repository.GetAllUsers();
        var usersDto = UserMapping.GetAllUsers(users);
        return Result<List<GetAllUsersDto>>.Success(usersDto);
    }

    public async Task<Result<bool>> BlockUser(uint? userId)
    {
        if (userId == null) return Result<bool>.Failure("Incorrect user id", HttpStatusCode.BadRequest);
        
        var userInResult = await GetUserById(userId);
        if(!userInResult.IsSuccess) return Result<bool>.Failure("User not found", HttpStatusCode.NotFound);
        
        var user = userInResult.Data;
        await repository.BlockUser(user); 
        
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> ActivateUser(uint? userId)
    {
        if (userId == null) return Result<bool>.Failure("Incorrect user id", HttpStatusCode.BadRequest);
        
        var userInResult = await GetUserById(userId);
        if (!userInResult.IsSuccess) return Result<bool>.Failure("User not found", HttpStatusCode.NotFound);
        
        var user = userInResult.Data;
        await repository.ActivateUser(user);
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> AddUserToAdmin(uint? userId)
    {
        if  (userId == null) return Result<bool>.Failure("Incorrect user id", HttpStatusCode.BadRequest);
        
        var userInResult = await GetUserById(userId);
        if(!userInResult.IsSuccess) return Result<bool>.Failure("User not found", HttpStatusCode.NotFound);
        
        var user = userInResult.Data;
        await repository.AddUserToAdmin(user);
        
        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> RemoveUserFromAdmin(uint? userId)
    {
        if  (userId == null) return Result<bool>.Failure("Incorrect user id", HttpStatusCode.BadRequest);
        
        var userInResult = await GetUserById(userId);
        if(!userInResult.IsSuccess) return Result<bool>.Failure("User not found", HttpStatusCode.NotFound);
        
        var user = userInResult.Data;
        await repository.RemoveUserFromAdmin(user);
        
        return Result<bool>.Success(true);
    }
}