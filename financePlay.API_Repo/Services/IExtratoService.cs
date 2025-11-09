using financePlay.API.Models;
using Microsoft.AspNetCore.Http;

namespace financePlay.API.Services
{
    public interface IExtratoService
    {
        Task<Extrato> ProcessarExtratoCSV(IFormFile file, int usuarioId);
    }
}
