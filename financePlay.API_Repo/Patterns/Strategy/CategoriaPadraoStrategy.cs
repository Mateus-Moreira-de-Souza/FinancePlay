using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;

namespace financePlay.API.Patterns.Strategy
{
    public class CategoriaPadraoStrategy : ICategorizacaoStrategy
    {
        private readonly IUnitOfWork _uow;

        public CategoriaPadraoStrategy(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CategorizarAsync(Transacao transacao)
        {
            // Lógica de categorização padrão, talvez baseada em palavras-chave na descrição
            if (transacao.Descricao.Contains("Uber", StringComparison.OrdinalIgnoreCase))
            {
                transacao.Categoria = "Transporte";
            }
            else if (transacao.Descricao.Contains("Supermercado", StringComparison.OrdinalIgnoreCase) || transacao.Descricao.Contains("Mercado", StringComparison.OrdinalIgnoreCase))
            {
                transacao.Categoria = "Alimentação";
            }
            else
            {
                transacao.Categoria = "Outros";
            }

            // A transação será salva no CommitAsync do Service que a chamou.
            await Task.CompletedTask;
        }
    }
}
