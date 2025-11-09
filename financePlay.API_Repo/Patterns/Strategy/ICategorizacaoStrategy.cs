using financePlay.API.Models;

namespace financePlay.API.Patterns.Strategy
{
    public interface ICategorizacaoStrategy
    {
        Task CategorizarAsync(Transacao transacao);
    }
}
