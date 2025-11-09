
using financePlay.API.Data;
using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financePlay.API.Repositories.Implementations
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FinancePlayDbContext ctx) : base(ctx) { }

        public async Task<Usuario?> GetByEmailAsync(string email)
            => await _ctx.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }
}
