using FinancePlay.API.DTOs;
using FinancePlay.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinancePlay.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;

        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        private int ObterIdUsuario()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(claim.Value);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var idUsuario = ObterIdUsuario();
            var transacoes = await _service.ListarTransacoesUsuarioAsync(idUsuario);
            return Ok(transacoes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacaoDTO dto)
        {
            var idUsuario = ObterIdUsuario();
            var sucesso = await _service.AdicionarTransacaoAsync(dto, idUsuario);
            if (!sucesso) return BadRequest("Extrato inválido ou não pertence ao usuário.");
            return Ok("Transação cadastrada com sucesso.");
        }
    }
}
