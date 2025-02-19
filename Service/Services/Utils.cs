using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public static class Utils
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 20000;

        public static string HashPassword(string password, out string salt)
        {
            // Generate a random salt
            var saltBytes = new byte[SaltSize];
            RandomNumberGenerator.Fill(saltBytes);
            salt = Convert.ToBase64String(saltBytes);

            // Hash the password using PBKDF2
            using var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256);
            var hashBytes = deriveBytes.GetBytes(KeySize);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedSalt, string storedHash)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);

            using var deriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, Iterations, HashAlgorithmName.SHA256);
            var enteredHashBytes = deriveBytes.GetBytes(KeySize);
            var enteredHash = Convert.ToBase64String(enteredHashBytes);

            return storedHash == enteredHash;
        }
    }
}
