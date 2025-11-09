
using System.ComponentModel.DataAnnotations;
using financePlay.API.Models.Enums;

namespace financePlay.API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string CodigoUsuario { get; set; } = default!;

        [Required, MaxLength(100)]
        public string Nome { get; set; } = default!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = default!;

        [Required]
        public string CpfHash { get; set; } = default!;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string SenhaHash { get; set; } = default!;

        public int Vidas { get; set; } = 50; // Requisito 12

        public NivelUsuario NivelUsuario { get; set; } = NivelUsuario.INICIANTE;

        public StatusConta StatusConta { get; set; } = StatusConta.ATIVA;

        public DateTime? UltimoAcesso { get; set; }

        public int TentativasLogin { get; set; }

        public DateTime? BloqueadoAte { get; set; }

        public decimal Renda { get; set; } = 0; // Corrigido para Renda (Requisito 7, 11, 13)

        public decimal MetaEconomiaPorcentagem { get; set; } = 20; // Corrigido para MetaEconomiaPorcentagem (Requisito 11)

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public string? Conquistas { get; set; } // Requisito 19

        public ICollection<Extrato> Extratos { get; set; } = new List<Extrato>();
    }
}
