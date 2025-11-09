using financePlay.API.Models;

namespace financePlay.API.Patterns.Observer
{
    public interface ITransacaoObserver
    {
        Task Update(Transacao transacao);
    }
}
