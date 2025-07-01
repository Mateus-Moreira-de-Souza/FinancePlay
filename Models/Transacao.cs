using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePlay.API.Models
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodigoTransacao { get; set; }

        [Required]
        public int IdExtrato { get; set; }

        [ForeignKey("IdExtrato")]
        public Extrato Extrato { get; set; }

        [Required]
        public DateTime DataTransacao { get; set; }

        [Required]
        public string DescricaoOriginal { get; set; }

        public string DescricaoLimpa { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public string Cnpj { get; set; }

        public string Categoria { get; set; }

        public string Subcategoria { get; set; }

        [Required]
        public string TipoTransacao { get; set; }

        public bool EhGastoEssencial { get; set; }

        public string ConfiabilidadeCategoria { get; set; } = "MEDIA";

        public bool Processada { get; set; }
    }
}
