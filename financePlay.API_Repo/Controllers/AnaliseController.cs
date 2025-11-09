using financePlay.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace financePlay.API.Controllers
{
    [Authorize] // Proteger os endpoints
    [ApiController]
    [Route("api/[controller]")]
    public class AnaliseController : ControllerBase
    {
        private readonly IAnaliseService _analiseService;

        public AnaliseController(IAnaliseService analiseService)
        {
            _analiseService = analiseService;
        }

        // Requisito 13: Ranking
        [HttpGet("ranking")]
        public async Task<IActionResult> GetRanking()
        {
            var ranking = await _analiseService.GetRankingAsync();
            return Ok(ranking);
        }

        // Requisito 6: Insights
        [HttpGet("insights/{usuarioId:int}")]
        public async Task<IActionResult> GetInsights(int usuarioId)
        {
            var insights = await _analiseService.GetInsightsAsync(usuarioId);
            return Ok(insights);
        }

        // Requisito 9: Histórico Mensal
        [HttpGet("historico/{usuarioId:int}")]
        public async Task<IActionResult> GetHistoricoMensal(int usuarioId)
        {
            var historico = await _analiseService.GetHistoricoMensalAsync(usuarioId);
            return Ok(historico);
        }

        // Requisito 8: Recomendações
        [HttpGet("recomendacoes/{usuarioId:int}")]
        public async Task<IActionResult> GetRecomendacoes(int usuarioId)
        {
            var recomendacoes = await _analiseService.GetRecomendacoesAsync(usuarioId);
            return Ok(recomendacoes);
        }

        // Requisito 20: Exportação de Relatório
        [HttpGet("exportar/{usuarioId:int}")]
        public async Task<IActionResult> ExportarRelatorio(int usuarioId)
        {
            var csvBytes = await _analiseService.ExportarRelatorioAsync(usuarioId);
            return File(csvBytes, "text/csv", $"relatorio_financeiro_{usuarioId}.csv");
        }
    }
}
