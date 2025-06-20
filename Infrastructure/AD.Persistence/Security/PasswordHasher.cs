using System.Security.Cryptography;
using AD.Application.Interfaces;

namespace AD.Persistence.Security;

public class PasswordHasher : IPasswordHasher
{
    private const int Size = 96;

    public bool IsValid(string password, string hash, string salt) => Hash(password, salt) == hash;

    public string Hash(string password, string salt)
    {
        var rfc = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 3, HashAlgorithmName.SHA512);

        var hash = rfc.GetBytes(Size);

        return Convert.ToBase64String(hash);
    }

    public string GenerateSalt()
    {
        var salt = new byte[Size];

        RandomNumberGenerator.Create().GetNonZeroBytes(salt);

        return Convert.ToBase64String(salt);
    }
}