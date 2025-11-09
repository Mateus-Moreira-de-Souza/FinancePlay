
using financePlay.API.Data;
using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financePlay.API.Repositories.Implementations
{
    public class TransacaoRepository : GenericRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(FinancePlayDbContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Transacao>> GetByExtratoAsync(int idExtrato)
            => await _ctx.Transacoes.Where(t => t.ExtratoId == idExtrato).AsNoTracking().ToListAsync();
    }
}
