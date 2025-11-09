
namespace financePlay.API.Repositories.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IExtratoRepository Extratos { get; }
        ITransacaoRepository Transacoes { get; }
        Task<int> CommitAsync();
    }
}
