using System.Text;
using Forms.Application.Interfaces.ISecurity;
using SHA3.Net;

namespace Forms.DAL.Security;

public class PasswordHasher: IPasswordHasher
{
    public string CalculateHash(string password)
    {
        byte[] passwordValue = Encoding.UTF8.GetBytes(password);
        var resultHash = Sha3.Sha3256().ComputeHash(passwordValue);
        string passwordHash = BitConverter.ToString(resultHash).Replace("-", string.Empty).ToLower();
        return passwordHash;
    }
}