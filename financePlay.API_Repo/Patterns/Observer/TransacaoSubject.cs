using financePlay.API.Models;

namespace financePlay.API.Patterns.Observer
{
    public class TransacaoSubject
    {
        private readonly List<ITransacaoObserver> _observers = new List<ITransacaoObserver>();

        public void Attach(ITransacaoObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ITransacaoObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task Notify(Transacao transacao)
        {
            foreach (var observer in _observers)
            {
                await observer.Update(transacao);
            }
        }
    }
}
