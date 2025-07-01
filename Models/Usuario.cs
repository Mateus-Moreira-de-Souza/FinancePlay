using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePlay.API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(12)]
        public string CodigoUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string CpfHash { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        public int Vidas { get; set; } = 50;

        public string NivelUsuario { get; set; } = "INICIANTE";

        public string StatusConta { get; set; } = "ATIVA";

        public DateTime? UltimoAcesso { get; set; }

        public int TentativasLogin { get; set; }

        public DateTime? BloqueadoAte { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}

