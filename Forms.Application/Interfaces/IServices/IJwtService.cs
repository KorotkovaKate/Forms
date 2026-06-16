using Forms.Core.Models;

namespace Forms.Application.Interfaces.IServices;

public interface IJwtService
{
    public string CreateToken(User user);
}