using System;

namespace FinancePlay.API.DTOs
{
    public class TransacaoDTO
    {
        public string CodigoTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public string DescricaoOriginal { get; set; }
        public decimal Valor { get; set; }
        public string Cnpj { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string TipoTransacao { get; set; } // CREDITO ou DEBITO
        public bool EhGastoEssencial { get; set; }
        public string ConfiabilidadeCategoria { get; set; }
        public int IdExtrato { get; set; } // (pode ser fixo até tratarmos upload)
    }
}

