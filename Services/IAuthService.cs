using financePlay.API.DTOs;
using System.Threading.Tasks;

namespace FinancePlay.API.Services
{
    public interface IAuthService
    {
        Task<bool> RegistrarAsync(RegisterDTO dto);
        Task<AuthResponseDTO> LoginAsync(LoginDTO dto);
    }
}

