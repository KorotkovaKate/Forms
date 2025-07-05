using Forms.Core.Enums;
using Forms.Core.Models;

namespace Forms.Core.Interfaces.IRepositories;

public interface IUserRepository
{
    public Task<User?> Authorize(string email, string passwordHash);
    public Task Registrate(User user);
    public Task<List<User>> GetAllUsers();
    public Task<User?> GetUserById(uint userId);
    public Task BlockUser(User user);
    public Task ActivateUser(User user);
}