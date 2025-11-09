
using financePlay.API.Models;

namespace financePlay.API.Repositories.Interfaces
{
    public interface ITransacaoRepository : IGenericRepository<Transacao>
    {
        Task<IEnumerable<Transacao>> GetByExtratoAsync(int idExtrato);
    }
}
