using Forms.Application.Interfaces.ICommon;
using Microsoft.AspNetCore.Http;

namespace Forms.DAL.Security;

public class UserContext (IHttpContextAccessor contextAccessor): IUserContext
{
    private readonly HttpContext? _httpContext = contextAccessor.HttpContext;

    public uint UserId
    {
        get
        {
            var idClaim = _httpContext?.User.FindFirst("id")?.Value;
            return uint.TryParse(idClaim, out var id) ? id : 0;
        }
    }
    public string Email => _httpContext?.User.FindFirst("email")?.Value ?? string.Empty;
    public string Role => _httpContext?.User.FindFirst("role")?.Value ?? string.Empty;
}