using FinancePlay.API.DTOs;
using FinancePlay.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinancePlay.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExtratoController : ControllerBase
    {
        private readonly IExtratoService _service;

        public ExtratoController(IExtratoService service)
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
            var extratos = await _service.ListarExtratosUsuarioAsync(idUsuario);
            return Ok(extratos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExtratoUploadDTO dto)
        {
            var idUsuario = ObterIdUsuario();
            var sucesso = await _service.AdicionarExtratoAsync(dto, idUsuario);
            if (!sucesso) return BadRequest("Este arquivo já foi enviado anteriormente.");
            return Ok("Extrato importado com sucesso.");
        }
    }
}
