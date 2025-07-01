using Microsoft.EntityFrameworkCore;
using FinancePlay.API.Models;

namespace FinancePlay.API.Data
{
    public class FinancePlayDbContext : DbContext
    {
        public FinancePlayDbContext(DbContextOptions<FinancePlayDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Extrato> Extratos { get; set; }
        // ... Adicionar os outros DbSet conforme os Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Adicione regras extras aqui, se necessário
        }
    }
}

