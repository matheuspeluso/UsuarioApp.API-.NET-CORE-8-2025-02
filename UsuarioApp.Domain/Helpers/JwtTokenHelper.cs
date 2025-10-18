using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Domain.Helpers
{
    public class JwtTokenHelper
    {
        public static string GenerateToken(string email, string perfil)
        {
            //chave secreta para assinar o token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0E59ADB6-B774-4932-8A63-62B36B50F0B1"));

            //criptografar a assinatura do token
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //informações do usuario do token
            var Claims = new[] {
               new Claim(ClaimTypes.Name, email), // nome do usuário autenticado
               new Claim(ClaimTypes.Role, perfil) // perfil do usuário autenticado
            };

            //criando o token JWT
            var token = new JwtSecurityToken(
                claims: Claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
