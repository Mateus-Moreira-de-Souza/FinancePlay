
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using financePlay.API.Models.Enums;

namespace financePlay.API.Models
{
    public class Extrato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodigoExtrato { get; set; } = default!;

        [Required]
        public int UsuarioId { get; set; } // Corrigido para UsuarioId (convenção)

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; } = default!;

        public DateTime DataUpload { get; set; } = DateTime.Now;

        [Required]
        public TipoArquivo TipoArquivo { get; set; }

        public string? NomeArquivo { get; set; } // Corrigido para NomeArquivo (ExtratoService)

        public string? HashArquivo { get; set; }

        public string StatusProcessamento { get; set; } = "Processando"; // Corrigido para StatusProcessamento (ExtratoService)

        public int TotalTransacoes { get; set; }

        public decimal ValorTotalGastos { get; set; }

        public decimal ValorTotalReceitas { get; set; }

        public DateTime? PeriodoInicio { get; set; }

        public DateTime? PeriodoFim { get; set; }

        public string? LogProcessamento { get; set; }

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
