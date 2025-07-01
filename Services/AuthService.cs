using FinancePlay.API.Data;
using financePlay.API.DTOs;
using FinancePlay.API.Models;
using FinancePlay.API.Helpers;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;

namespace FinancePlay.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly FinancePlayDbContext _context;

        public AuthService(FinancePlayDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarAsync(RegisterDTO dto)
        {
            var emailExistente = await _context.Usuarios.AnyAsync(u => u.Email == dto.Email);
            if (emailExistente) return false;

            var novoUsuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                DataNascimento = dto.DataNascimento,
                CpfHash = BCrypt.Net.BCrypt.HashPassword(dto.Cpf),
                CodigoUsuario = Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper()
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
                return null;

            var token = JwtHelper.GerarToken(usuario);

            return new AuthResponseDTO
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Vidas = usuario.Vidas
            };
        }
    }
}

