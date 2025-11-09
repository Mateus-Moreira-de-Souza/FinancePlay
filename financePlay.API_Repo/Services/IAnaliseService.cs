using financePlay.API.Models;

namespace financePlay.API.Services
{
    public interface IAnaliseService
    {
        Task<IEnumerable<Usuario>> GetRankingAsync();
        Task<string> GetInsightsAsync(int usuarioId);
        Task<object> GetHistoricoMensalAsync(int usuarioId);
        Task<string> GetRecomendacoesAsync(int usuarioId);
        Task<byte[]> ExportarRelatorioAsync(int usuarioId);
    }
}
