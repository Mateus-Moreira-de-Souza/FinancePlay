
using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using financePlay.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace financePlay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtratosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IExtratoService _extratoService;

        public ExtratosController(IUnitOfWork uow, IExtratoService extratoService)
        {
            _uow = uow;
            _extratoService = extratoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _uow.Extratos.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var extrato = await _uow.Extratos.GetWithTransacoesAsync(id);
            return extrato is null ? NotFound() : Ok(extrato);
        }

        [HttpPost("upload/{usuarioId:int}")]
        public async Task<IActionResult> UploadExtrato(int usuarioId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo não enviado.");
            }

            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Apenas arquivos CSV são permitidos.");
            }

            try
            {
                // TODO: Adicionar validação de usuário (JWT)
                var extrato = await _extratoService.ProcessarExtratoCSV(file, usuarioId);
                return CreatedAtAction(nameof(Get), new { id = extrato.Id }, extrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar o extrato: {ex.Message}");
            }
        }
    }
}
