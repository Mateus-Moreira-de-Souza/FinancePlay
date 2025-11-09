using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;

namespace financePlay.API.Patterns.Observer
{
    public class GamificacaoObserver : ITransacaoObserver
    {
        private readonly IUnitOfWork _uow;

        public GamificacaoObserver(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Update(Transacao transacao)
        {
            var usuario = await _uow.Usuarios.GetByIdAsync(transacao.UsuarioId);

            if (usuario == null) return;

            // Lógica de Gamificação (Requisito 7 e 12)
            // Evento: Gasto acima do recomendado -> -1 vida
            // Vamos simular que o "recomendado" é a meta de economia mensal do usuário.
            // Se o gasto for muito alto (ex: > 10% da renda), ele perde uma vida.

            if (transacao.Valor > 0) // Apenas gastos (saídas)
            {
                decimal limiteGasto = usuario.Renda * (1 - usuario.MetaEconomiaPorcentagem / 100);
                
                // Simulação: Se o gasto for maior que 10% da renda, perde vida.
                if (transacao.Valor > (usuario.Renda * 0.1m))
                {
                    if (usuario.Vidas > 0)
                    {
                        usuario.Vidas--;
                        _uow.Usuarios.Update(usuario);
                        // O CommitAsync será chamado pelo Service que notificou.
                        Console.WriteLine($"Usuário {usuario.Id} perdeu 1 vida devido a gasto alto: {transacao.Valor}");
                    }
                }
            }

            // TODO: Implementar lógica para conquistas (Requisito 19)
            // Ex: 30 dias sem ultrapassar limite -> +1 conquista
        }
    }
}
