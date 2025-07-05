using Forms.Core.Enums;
using Forms.Core.Interfaces.IRepositories;
using Forms.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Forms.DAL.Repositories;

public class UserRepository(FormDbContext context): IUserRepository
{
    public async Task<User?> Authorize(string email, string passwordHash)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == passwordHash);
        return user;
    }

    public async Task Registrate(User user)
    {
        var checkUser = await context.Users
            .FirstOrDefaultAsync(check => check.Email == user.Email);
        if (checkUser != null) { throw new Exception("User already exists"); }
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await context.Users.AsNoTracking().OrderBy(user => user.UserName).ToListAsync();
    }

    public async Task<User?> GetUserById(uint userId)
    {
        return await context.Users
            .FindAsync(userId);
    }

    public async Task BlockUser(User user)
    {
        user.Status = UserStatus.Blocked;
        await context.SaveChangesAsync();
    }

    public async Task ActivateUser(User user)
    {
        user.Status = UserStatus.Active;
        await context.SaveChangesAsync();
    }
}