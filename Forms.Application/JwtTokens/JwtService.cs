using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Forms.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Forms.Application.JwtTokens;

public class JwtService(IOptions<AuthSettings> options)
{
    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email),
        };
        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(options.Value.TokenLifetime),
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);

    }
}