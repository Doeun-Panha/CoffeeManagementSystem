using System;
using System.Security.Cryptography;

namespace CoffeeManagementSystem.Models.Classes
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int KeySize = 20;
        private const int Iterations = 10000;

        public static string HashPassword(string password, out string salt)
        {
            byte[] saltBytes = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(KeySize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedSalt, string storedHash)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] newHashBytes = pbkdf2.GetBytes(KeySize);
                string newHash = Convert.ToBase64String(newHashBytes);

                return newHash == storedHash;
            }
        }
    }
}
