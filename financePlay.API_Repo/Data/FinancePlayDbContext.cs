
using financePlay.API.Models;
using financePlay.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace financePlay.API.Data
{
    public class FinancePlayDbContext : DbContext
    {
        public FinancePlayDbContext(DbContextOptions<FinancePlayDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Extrato> Extratos => Set<Extrato>();
        public DbSet<Transacao> Transacoes => Set<Transacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enums como string (compatível com seu SQL)
            var nivelConv = new EnumToStringConverter<NivelUsuario>();
            var statusContaConv = new EnumToStringConverter<StatusConta>();
            var tipoTransConv = new EnumToStringConverter<TipoTransacao>();
            var confiabConv = new EnumToStringConverter<ConfiabilidadeCategoria>();
            var tipoArquivoConv = new EnumToStringConverter<TipoArquivo>();
            var statusExtratoConv = new EnumToStringConverter<StatusExtrato>();

            modelBuilder.Entity<Usuario>()
                .Property(p => p.NivelUsuario).HasConversion(nivelConv);

            modelBuilder.Entity<Usuario>()
                .Property(p => p.StatusConta).HasConversion(statusContaConv);

            modelBuilder.Entity<Transacao>()
                .Property(p => p.TipoTransacao).HasConversion(tipoTransConv);

            modelBuilder.Entity<Transacao>()
                .Property(p => p.ConfiabilidadeCategoria).HasConversion(confiabConv);

            modelBuilder.Entity<Extrato>()
                .Property(p => p.TipoArquivo).HasConversion(tipoArquivoConv);

// Removido: Status foi substituído por StatusProcessamento (string)

            // Relations
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Extratos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Extrato>()
                .HasMany(e => e.Transacoes)
                .WithOne(t => t.Extrato)
                .HasForeignKey(t => t.ExtratoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
