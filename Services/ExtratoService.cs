using FinancePlay.API.Data;
using FinancePlay.API.DTOs;
using FinancePlay.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancePlay.API.Services
{
    public class ExtratoService : IExtratoService
    {
        private readonly FinancePlayDbContext _context;

        public ExtratoService(FinancePlayDbContext context)
        {
            _context = context;
        }

        public async Task<List<Extrato>> ListarExtratosUsuarioAsync(int idUsuario)
        {
            return await _context.Extratos
                .Where(e => e.IdUsuario == idUsuario)
                .OrderByDescending(e => e.DataUpload)
                .ToListAsync();
        }

        public async Task<bool> AdicionarExtratoAsync(ExtratoUploadDTO dto, int idUsuario)
        {
            var hashDuplicado = await _context.Extratos.AnyAsync(e => e.HashArquivo == dto.HashArquivo);
            if (hashDuplicado) return false;

            var novo = new Extrato
            {
                CodigoExtrato = Guid.NewGuid().ToString("N").Substring(0, 15).ToUpper(),
                IdUsuario = idUsuario,
                TipoArquivo = dto.TipoArquivo,
                NomeArquivoOriginal = dto.NomeArquivoOriginal,
                HashArquivo = dto.HashArquivo,
                Status = "PROCESSADO",
                PeriodoInicio = dto.PeriodoInicio,
                PeriodoFim = dto.PeriodoFim
            };

            _context.Extratos.Add(novo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

