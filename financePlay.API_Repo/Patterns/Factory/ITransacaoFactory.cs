using financePlay.API.Models;

namespace financePlay.API.Patterns.Factory
{
    public interface ITransacaoFactory
    {
        Transacao CreateTransacao(string[] data);
    }
}
