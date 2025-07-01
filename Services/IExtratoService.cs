using FinancePlay.API.DTOs;
using FinancePlay.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FinancePlay.API.Services
{
    public interface IExtratoService
    {
        Task<List<Extrato>> ListarExtratosUsuarioAsync(int idUsuario);
        Task<bool> AdicionarExtratoAsync(ExtratoUploadDTO dto, int idUsuario);
    }
}

