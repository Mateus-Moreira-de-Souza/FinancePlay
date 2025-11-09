
using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financePlay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public TransacoesController(IUnitOfWork uow) => _uow = uow;

        [HttpGet("por-extrato/{idExtrato:int}")]
        public async Task<IActionResult> GetByExtrato(int idExtrato)
            => Ok(await _uow.Transacoes.GetByExtratoAsync(idExtrato));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transacao model)
        {
            await _uow.Transacoes.AddAsync(model);
            await _uow.CommitAsync();
            return CreatedAtAction(nameof(GetByExtrato), new { idExtrato = model.ExtratoId }, model);
        }
    }
}
