using FluentAssertions;
using Forms.Application.DTOs.UserDTOs;
using Forms.Application.Interfaces.ISecurity;
using Forms.Application.Interfaces.IServices;
using Forms.Application.Services;
using Forms.Core.Enums;
using Forms.Core.Exceptions;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.AspNetCore.Identity;
using NSubstitute;

namespace Forms.Application.Tests.Services;

public class UserServiceTests
{
    private readonly IUserRepository _userRepositoryMock;
    private readonly IPasswordHasher _passwordHasherMock;
    private readonly IJwtService _jwtServiceMock;
    
    private readonly UserService _sut;

    public UserServiceTests()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _passwordHasherMock = Substitute.For<IPasswordHasher>();
        _jwtServiceMock = Substitute.For<IJwtService>();
        
        _sut = new UserService(_userRepositoryMock, _passwordHasherMock, _jwtServiceMock);
    }
    
    public class Authorize: UserServiceTests
    {
        [Fact]
        public async Task Authorize_ShouldReturnSuccess_WhenDtoValid()
        {
            var validDto = new AuthorizationDto()
            {
                Email = "test@gmail.com",
                Password = "84628194"
            };
            
            string fakeJwt = "fakeJwt";
            string fakeHash = "fakeHash";
            var fakeUser = new User
            {
                Id = 1u,
                Email = "test@gmail.com",
                Status = UserStatus.Active,
                Role = UserRole.User
            };
            
            _userRepositoryMock.Authorize(validDto.Email, fakeHash).Returns(fakeUser);
            _passwordHasherMock.CalculateHash(validDto.Password).Returns(fakeHash);
            _jwtServiceMock.CreateToken(fakeUser).Returns(fakeJwt);
            
            var result = await _sut.Authorize(validDto);
        
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Token.Should().NotBeNullOrEmpty();
        
            await _userRepositoryMock
                .Received(1)
                .Authorize(validDto.Email, fakeHash);
        }
        
        [Theory]
        [InlineData(null, "12345678")]
        [InlineData("", "12345678")]
        [InlineData("test", "12345678")]
        [InlineData("test@gmail.com", "")]
        [InlineData("test@gmail.com", "   ")]
        [InlineData("test@gmail.com", "1234")]
        [InlineData("test@gmail.com", null)]
        public async Task AddComment_ShouldThrowValidationException_WhenDataIsInvalid(string? email, string? password)
        {
            var invalidDto = new AuthorizationDto()
            {
                Email = email,
                Password = password
            };
        
            Func<Task> act = async () => await _sut.Authorize(invalidDto);
        
            await act.Should().ThrowAsync<ValidationException>();
            await _userRepositoryMock
                .DidNotReceive()
                .Authorize(Arg.Any<string>(),Arg.Any<string>());
        }
    }
}