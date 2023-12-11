using System;
using System.Security.Cryptography;
using System.Text;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Services
{
    public class HashingService
    {
        public static string HashData(string userData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(userData);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
