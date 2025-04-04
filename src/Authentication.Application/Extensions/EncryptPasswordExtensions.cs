using System.Security.Cryptography;
using System.Text;

namespace Authentication.Application.Extensions;

public static class EncryptPasswordExtensions
{
    public static string EncryptPassword(this string password)
    {
        var enc = Encoding.GetEncoding(0);
        byte[] buffer = enc.GetBytes(password);
        var sha1 = SHA1.Create();
        return BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
    }    
}
