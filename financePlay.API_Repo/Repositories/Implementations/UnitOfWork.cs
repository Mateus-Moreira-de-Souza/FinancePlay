
using financePlay.API.Data;
using financePlay.API.Repositories.Interfaces;

namespace financePlay.API.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancePlayDbContext _ctx;

        public IUsuarioRepository Usuarios { get; }
        public IExtratoRepository Extratos { get; }
        public ITransacaoRepository Transacoes { get; }

        public UnitOfWork(FinancePlayDbContext ctx, 
                          IUsuarioRepository usuarios, 
                          IExtratoRepository extratos, 
                          ITransacaoRepository transacoes)
        {
            _ctx = ctx;
            Usuarios = usuarios;
            Extratos = extratos;
            Transacoes = transacoes;
        }

        public async Task<int> CommitAsync() => await _ctx.SaveChangesAsync();

        public ValueTask DisposeAsync() => _ctx.DisposeAsync();
    }
}
