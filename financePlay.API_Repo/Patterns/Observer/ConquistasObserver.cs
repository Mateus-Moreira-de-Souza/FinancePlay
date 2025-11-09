using financePlay.API.Models;
using financePlay.API.Repositories.Interfaces;

namespace financePlay.API.Patterns.Observer
{
    public class ConquistasObserver : ITransacaoObserver
    {
        private readonly IUnitOfWork _uow;

        public ConquistasObserver(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Update(Transacao transacao)
        {
            // Lógica de Conquistas (Requisito 19)
            // Exemplo: Se o usuário atingir a meta de economia mensal, ganha uma conquista.
            // Isso seria melhor verificado no final do mês, mas vamos simular uma conquista simples.

            var usuario = await _uow.Usuarios.GetByIdAsync(transacao.UsuarioId);

            if (usuario == null) return;

            // Simulação de Conquista: "Primeira Transação Registrada"
            // Isso deve ser verificado de forma mais inteligente, mas serve como exemplo.
            if (usuario.Conquistas == null)
            {
                usuario.Conquistas = "Primeira Transação Registrada";
                _uow.Usuarios.Update(usuario);
                Console.WriteLine($"Usuário {usuario.Id} ganhou a conquista: Primeira Transação Registrada");
            }

            await Task.CompletedTask;
        }
    }
}
