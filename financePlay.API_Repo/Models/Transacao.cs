
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using financePlay.API.Models.Enums;

namespace financePlay.API.Models
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; } // Adicionado para Observer e Services

        [Required]
        public string CodigoTransacao { get; set; } = default!;

        [Required]
        public int ExtratoId { get; set; } // Corrigido para ExtratoId (convenção)

        [ForeignKey(nameof(ExtratoId))]
        public Extrato Extrato { get; set; } = default!;

        [Required]
        public DateTime Data { get; set; } // Corrigido para Data (Factory)

        [Required, MaxLength(500)]
        public string Descricao { get; set; } = default!; // Corrigido para Descricao (Factory, Strategy)

        [MaxLength(255)]
        public string? DescricaoLimpa { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [MaxLength(18)]
        public string? Cnpj { get; set; }

        [MaxLength(100)]
        public string? Categoria { get; set; }

        [MaxLength(100)]
        public string? Subcategoria { get; set; }

        [Required]
        public TipoTransacao TipoTransacao { get; set; }

        public bool EhGastoEssencial { get; set; }

        public ConfiabilidadeCategoria ConfiabilidadeCategoria { get; set; } = ConfiabilidadeCategoria.MEDIA;

        public bool Processada { get; set; }
    }
}
