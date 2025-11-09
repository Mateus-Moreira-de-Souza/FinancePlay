
using financePlay.API.Data;
using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financePlay.API.Repositories.Implementations
{
    public class ExtratoRepository : GenericRepository<Extrato>, IExtratoRepository
    {
        public ExtratoRepository(FinancePlayDbContext ctx) : base(ctx) { }

        public async Task<Extrato?> GetWithTransacoesAsync(int id)
            => await _ctx.Extratos.Include(e => e.Transacoes).FirstOrDefaultAsync(e => e.Id == id);
    }
}
