using Microsoft.AspNetCore.Identity;
using System;
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
            byte[] bytes = Encoding.Unicode.GetBytes(password+model.Email);
            byte[] inArray = HashAlgorithm.Create("SHA-256").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);

        }
    }

}
