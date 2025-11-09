using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;

namespace financePlay.API.Patterns.Strategy
{
    public class CategoriaCnpjStrategy : ICategorizacaoStrategy
    {
        private readonly IUnitOfWork _uow;

        public CategoriaCnpjStrategy(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CategorizarAsync(Transacao transacao)
        {
            // Lógica de categorização por CNPJ
            // O requisito menciona "Strategy Pattern com tabela CNPJ->categoria".
            // Como não temos a tabela, vamos simular a lógica.

            // 1. Extrair CNPJ da descrição (simulação)
            string cnpj = ExtractCnpj(transacao.Descricao);

            if (!string.IsNullOrEmpty(cnpj))
            {
                // 2. Consultar tabela (simulação)
                string? categoriaMapeada = await ConsultarMapeamentoCnpj(cnpj);

                if (!string.IsNullOrEmpty(categoriaMapeada))
                {
                    transacao.Categoria = categoriaMapeada;
                }
                else
                {
                    // Se não encontrar, cai para a categorização padrão
                    await new CategoriaPadraoStrategy(_uow).CategorizarAsync(transacao);
                }
            }
            else
            {
                // Se não tiver CNPJ, cai para a categorização padrão
                await new CategoriaPadraoStrategy(_uow).CategorizarAsync(transacao);
            }
        }

        private string ExtractCnpj(string descricao)
        {
            // Implementação real exigiria Regex ou lógica de extração mais robusta.
            // Simulação: se a descrição contiver "CNPJ:", retorna um CNPJ fictício.
            if (descricao.Contains("CNPJ:", StringComparison.OrdinalIgnoreCase))
            {
                return "12345678000190"; // CNPJ Fictício
            }
            return string.Empty;
        }

        private async Task<string?> ConsultarMapeamentoCnpj(string cnpj)
        {
            // Simulação de consulta ao banco de dados para mapeamento CNPJ -> Categoria
            await Task.Delay(1); // Simula async DB call

            if (cnpj == "12345678000190")
            {
                return "Restaurante";
            }
            return null;
        }
    }
}
