
using financePlay.API.Models;

namespace financePlay.API.Repositories.Interfaces
{
    public interface IExtratoRepository : IGenericRepository<Extrato>
    {
        Task<Extrato?> GetWithTransacoesAsync(int id);
    }
}
