using financePlay.API.Models;
using System.Globalization;

namespace financePlay.API.Patterns.Factory
{
    public class TransacaoFactory : ITransacaoFactory
    {
        public Transacao CreateTransacao(string[] data)
        {
            // Assumindo que o CSV tem o formato: Data, Descricao, Valor, Categoria (se houver)
            // O formato exato do CSV não foi fornecido, então farei uma suposição razoável.
            // O campo 'data' deve ser um array de strings representando as colunas do CSV.

            if (data.Length < 3)
            {
                throw new ArgumentException("Dados insuficientes para criar uma transação.");
            }

            // Exemplo de parsing (ajustar conforme o CSV real)
            DateTime dataTransacao = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
            string descricao = data[1];
            decimal valor = decimal.Parse(data[2], CultureInfo.InvariantCulture);
            string categoria = data.Length > 3 ? data[3] : "Não Categorizado";

            return new Transacao
            {
                Data = dataTransacao,
                Descricao = descricao,
                Valor = valor,
                Categoria = categoria,
                // Outras propriedades da Transacao, como UsuarioId, ExtratoId, etc.,
                // serão definidas no Service que usa a Factory.
            };
        }
    }
}
