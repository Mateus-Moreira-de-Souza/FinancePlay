using Microsoft.AspNetCore.Mvc;
using financePlay.API.DTOs;
using FinancePlay.API.Services;

namespace FinancePlay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegisterDTO dto)
        {
            var sucesso = await _authService.RegistrarAsync(dto);
            if (!sucesso) return BadRequest("E-mail já cadastrado.");
            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var resultado = await _authService.LoginAsync(dto);
            if (resultado == null) return Unauthorized("Credenciais inválidas.");
            return Ok(resultado);
        }
    }
}
