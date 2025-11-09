using financePlay.API.Models;

namespace financePlay.API.Patterns.Strategy
{
    public class CategorizacaoContext
    {
        private ICategorizacaoStrategy _strategy;

        public CategorizacaoContext(ICategorizacaoStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ICategorizacaoStrategy strategy)
        {
            _strategy = strategy;
        }

        public async Task CategorizarTransacaoAsync(Transacao transacao)
        {
            await _strategy.CategorizarAsync(transacao);
        }
    }
}
