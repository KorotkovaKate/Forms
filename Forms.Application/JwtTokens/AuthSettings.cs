namespace Forms.Application.JwtTokens;

public class AuthSettings
{
    public TimeSpan TokenLifetime { get; set; }
    public string SecretKey { get; set; }
}