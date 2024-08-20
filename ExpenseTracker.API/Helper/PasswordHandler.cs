using System;
using System.Security.Cryptography;
using System.Text;
namespace Helper
{
    public class PasswordHandler : IPasswordHandler
    {
        private readonly int _saltSize;
        private readonly int _hashSize;
        private readonly int _iterations;

        public PasswordHandler(int saltSize, int hashSize, int iterations)
        {
            _saltSize = saltSize;
            _hashSize = hashSize;
            _iterations = iterations;
        }

        public string HashPassword(string password)
        {
            // Generate a random salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[_saltSize];
                rng.GetBytes(salt);

                // Generate the hash
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations))
                {
                    byte[] hash = pbkdf2.GetBytes(_hashSize);

                    // Combine salt and hash
                    byte[] hashBytes = new byte[_saltSize + _hashSize];
                    Array.Copy(salt, 0, hashBytes, 0, _saltSize);
                    Array.Copy(hash, 0, hashBytes, _saltSize, _hashSize);

                    // Convert to Base64
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }


        public bool VerifyPassword(string password, string storedHash)
        {
            // Get hash bytes from stored hash
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extract salt from hash bytes
            byte[] salt = new byte[_saltSize];
            Array.Copy(hashBytes, 0, salt, 0, _saltSize);

            // Extract hash from hash bytes
            byte[] storedHashBytes = new byte[_hashSize];
            Array.Copy(hashBytes, _saltSize, storedHashBytes, 0, _hashSize);

            // Compute the hash on the provided password
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _iterations))
            {
                byte[] computedHash = pbkdf2.GetBytes(_hashSize);

                // Compare the computed hash with the stored hash
                for (int i = 0; i < storedHashBytes.Length; i++)
                {
                    if (storedHashBytes[i] != computedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

}
