using FluentAssertions;
using Forms.Application.DTOs.CommentDTOs;
using Forms.Application.Services;
using Forms.Core.Exceptions;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using NSubstitute;

namespace Forms.Application.Tests.Services;

public class CommentServiceTests
{
    private readonly ICommentRepository  _commentRepositoryMock;

    private readonly CommentService _sut;

    public CommentServiceTests()
    {
        _commentRepositoryMock = Substitute.For<ICommentRepository>();
        _sut = new CommentService(_commentRepositoryMock);
    }

    public class AddComment: CommentServiceTests
    {
        [Fact]
        public async Task AddComment_ShouldReturnSuccess_WhenDtoValid()
        {
            var validDto = new AddCommentDto
            {
                UserId = 1,
                TemplateId = 5,
                Text = "test message"
            };
        
            var result = await _sut.AddComment(validDto);
        
            result.IsSuccess.Should().BeTrue();
        
            await _commentRepositoryMock.Received(1).AddComment(Arg.Any<Comment>());
        }
    
        [Theory]
        [InlineData(null, 1u, "test message")]
        [InlineData(1u, null, "test message")]
        [InlineData(1u, 1u, "")]
        [InlineData(1u, 1u, "   ")]
        public async Task AddComment_ShouldThrowValidationException_WhenDataIsInvalid(uint? userId, uint? templateId, string? text)
        {
            var invalidDto = new AddCommentDto
            {
                UserId = userId,
                TemplateId = templateId,
                Text = text
            };
        
            Func<Task> act = async () => await _sut.AddComment(invalidDto);
        
            await act.Should().ThrowAsync<ValidationException>();
            await _commentRepositoryMock.DidNotReceive().AddComment(Arg.Any<Comment>());
        }
    }
}