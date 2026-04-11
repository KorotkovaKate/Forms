namespace Forms.Application.Interfaces.ICommon;

public interface IUserContext
{
    uint UserId { get; }
    string Email { get; }
    string Role { get; }
}