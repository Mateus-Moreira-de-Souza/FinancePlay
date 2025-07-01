using FinancePlay.API.Data;
using FinancePlay.API.DTOs;
using FinancePlay.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancePlay.API.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly FinancePlayDbContext _context;

        public TransacaoService(FinancePlayDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transacao>> ListarTransacoesUsuarioAsync(int idUsuario)
        {
            return await _context.Transacoes
                .Include(t => t.Extrato)
                .Where(t => t.Extrato.IdUsuario == idUsuario)
                .OrderByDescending(t => t.DataTransacao)
                .ToListAsync();
        }

        public async Task<bool> AdicionarTransacaoAsync(TransacaoDTO dto, int idUsuario)
        {
            // Validação: o extrato informado pertence ao usuário?
            var extrato = await _context.Extratos
                .FirstOrDefaultAsync(e => e.Id == dto.IdExtrato && e.IdUsuario == idUsuario);

            if (extrato == null) return false;

            var nova = new Transacao
            {
                CodigoTransacao = dto.CodigoTransacao ?? Guid.NewGuid().ToString("N").Substring(0, 20).ToUpper(),
                IdExtrato = dto.IdExtrato,
                DataTransacao = dto.DataTransacao,
                DescricaoOriginal = dto.DescricaoOriginal,
                DescricaoLimpa = dto.DescricaoOriginal,
                Valor = dto.Valor,
                Cnpj = dto.Cnpj,
                Categoria = dto.Categoria,
                Subcategoria = dto.Subcategoria,
                TipoTransacao = dto.TipoTransacao,
                EhGastoEssencial = dto.EhGastoEssencial,
                ConfiabilidadeCategoria = dto.ConfiabilidadeCategoria,
                Processada = true
            };

            _context.Transacoes.Add(nova);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
