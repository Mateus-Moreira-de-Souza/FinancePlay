using System;

namespace FinancePlay.API.DTOs
{
    public class ExtratoUploadDTO
    {
        public string TipoArquivo { get; set; } // CSV, XLSX, etc.
        public string NomeArquivoOriginal { get; set; }
        public string HashArquivo { get; set; } // Hash SHA256 simulado
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFim { get; set; }
    }
}
