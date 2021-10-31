using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace TsBizcase.Api.Filters.Helpers
{
    public class ModelHasher
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static class Hasher
    {
        public static string Execute(ModelHasher model, string password)
        {
            //var passwordHasher = new PasswordHasher<ModelHasher>();
            //var hashedPassword = passwordHasher.HashPassword(model, password);

            //return hashedPassword;

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();

        }
    }

}
