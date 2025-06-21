namespace Forms.Application.Interfaces.ISecurity;

public interface IPasswordHasher
{
    public string CalculateHash(string password);
}