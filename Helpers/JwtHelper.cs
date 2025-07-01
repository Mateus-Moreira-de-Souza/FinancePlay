using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinancePlay.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace FinancePlay.API.Helpers
{
    public static class JwtHelper
    {
        private static string SecretKey = "financeplay_super_seguro_123"; // Trocar em produção

        public static string GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("codigo_usuario", usuario.CodigoUsuario),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "FinancePlay",
                audience: "FinancePlay",
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

