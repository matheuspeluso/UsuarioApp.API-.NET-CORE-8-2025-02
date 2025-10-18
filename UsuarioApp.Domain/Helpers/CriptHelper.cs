using System.Security.Cryptography;
using System.Text;

namespace UsuarioApp.Domain.Helpers
{
    public class CriptHelper
    {
        /// <summary>
        /// Método para retornar um valor criptografado com algoritmo SHA256
        /// </summary>
        /// <param name="value">Texto a ser criptografado</param>
        /// <returns>Hash SHA256 em formato hexadecimal</returns>
        public static string GetSHA256(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Converte os bytes para uma string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}