using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using System.Text;

namespace financePlay.API.Services
{
    public class AnaliseService : IAnaliseService
    {
        private readonly IUnitOfWork _uow;

        public AnaliseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // Requisito 13: Ranking de usuários
        public async Task<IEnumerable<Usuario>> GetRankingAsync()
        {
            // Ranking definido por: % economia x renda mensal
            var usuarios = await _uow.Usuarios.GetAllAsync();

            // Simulação de cálculo de score (precisaria de dados de transações reais)
            var ranking = usuarios
                .Select(u => new
                {
                    Usuario = u,
                    // Score = (Renda * MetaEconomia) - (Gastos * 0.5)
                    Score = u.Renda * (u.MetaEconomiaPorcentagem / 100) 
                    // Adicionar lógica de gastos reais aqui
                })
                .OrderByDescending(x => x.Score)
                .Select(x => x.Usuario)
                .ToList();

            return ranking;
        }

        // Requisito 6: Insights personalizados
        public async Task<string> GetInsightsAsync(int usuarioId)
        {
            var usuario = await _uow.Usuarios.GetByIdAsync(usuarioId);
            if (usuario == null) return "Usuário não encontrado.";

            // Simulação de insights
            return $"Olá {usuario.Nome}, você gastou 15% a mais em alimentação este mês. Considere reduzir em R$ 50,00 para atingir sua meta de economia de {usuario.MetaEconomiaPorcentagem}%.";
        }

        // Requisito 9: Histórico mensal
        public async Task<object> GetHistoricoMensalAsync(int usuarioId)
        {
            // Simulação de agrupamento por mês
            var transacoes = await _uow.Transacoes.FindAsync(t => t.UsuarioId == usuarioId);

            var historico = transacoes
                .GroupBy(t => new { t.Data.Year, t.Data.Month })
                .Select(g => new
                {
                    Ano = g.Key.Year,
                    Mes = g.Key.Month,
                    TotalGastos = g.Where(t => t.Valor < 0).Sum(t => t.Valor),
                    TotalReceitas = g.Where(t => t.Valor > 0).Sum(t => t.Valor),
                    Transacoes = g.ToList()
                })
                .OrderByDescending(h => h.Ano)
                .ThenByDescending(h => h.Mes)
                .ToList();

            return historico;
        }

        // Requisito 8: Recomendações de economia
        public async Task<string> GetRecomendacoesAsync(int usuarioId)
        {
            var usuario = await _uow.Usuarios.GetByIdAsync(usuarioId);
            if (usuario == null) return "Usuário não encontrado.";

            // Simulação de recomendação
            return $"Recomendação: Seu gasto médio com transporte é alto. Considere usar transporte público 2 vezes por semana para economizar cerca de R$ 100,00 por mês.";
        }

        // Requisito 20: Exportação de relatório (CSV)
        public async Task<byte[]> ExportarRelatorioAsync(int usuarioId)
        {
            var transacoes = await _uow.Transacoes.FindAsync(t => t.UsuarioId == usuarioId);

            var sb = new StringBuilder();
            sb.AppendLine("Data,Descricao,Valor,Categoria");

            foreach (var t in transacoes)
            {
                sb.AppendLine($"{t.Data:yyyy-MM-dd},{t.Descricao},{t.Valor},{t.Categoria}");
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
