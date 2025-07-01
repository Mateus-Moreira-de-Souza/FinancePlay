using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePlay.API.Models
{
    public class Extrato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodigoExtrato { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public DateTime DataUpload { get; set; } = DateTime.Now;

        [Required]
        public string TipoArquivo { get; set; }

        public string NomeArquivoOriginal { get; set; }

        public string HashArquivo { get; set; }

        public string Status { get; set; } = "PROCESSANDO";

        public int TotalTransacoes { get; set; }

        public decimal ValorTotalGastos { get; set; }

        public decimal ValorTotalReceitas { get; set; }

        public DateTime? PeriodoInicio { get; set; }

        public DateTime? PeriodoFim { get; set; }

        public string LogProcessamento { get; set; }
    }
}

