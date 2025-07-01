using FinancePlay.API.DTOs;
using FinancePlay.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancePlay.API.Services
{
    public interface ITransacaoService
    {
        Task<List<Transacao>> ListarTransacoesUsuarioAsync(int idUsuario);
        Task<bool> AdicionarTransacaoAsync(TransacaoDTO dto, int idUsuario);
    }
}
