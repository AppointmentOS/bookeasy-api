using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Bookeasy.Infrastructure.Identity
{
    public static class PasswordHasherUtility
    {
        // salt 
        public static string CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        public static string HashPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = Convert.FromBase64String(salt);
            argon2.DegreeOfParallelism = Environment.ProcessorCount; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 512; // 1 GB

            return Convert.ToBase64String(argon2.GetBytes(16));
        }

        public static bool VerifyPassword(string password, string salt, string hash)
        {
            return Convert.FromBase64String(HashPassword(password,salt)).SequenceEqual(Convert.FromBase64String(hash));
        }
    }
}