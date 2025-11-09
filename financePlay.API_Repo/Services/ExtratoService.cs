using financePlay.API.Models;
using financePlay.API.Patterns.Observer;
using financePlay.API.Patterns.Strategy;
using financePlay.API.Patterns.Factory;
using financePlay.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace financePlay.API.Services
{
    public class ExtratoService : IExtratoService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITransacaoFactory _transacaoFactory;
        private readonly CategorizacaoContext _categorizacaoContext;
        private readonly TransacaoSubject _transacaoSubject;

        public ExtratoService(IUnitOfWork uow, ITransacaoFactory transacaoFactory, CategorizacaoContext categorizacaoContext, TransacaoSubject transacaoSubject)
        {
            _uow = uow;
            _transacaoFactory = transacaoFactory;
            _categorizacaoContext = categorizacaoContext;
            _transacaoSubject = transacaoSubject;
        }

        public async Task<Extrato> ProcessarExtratoCSV(IFormFile file, int usuarioId)
        {
            var extrato = new Extrato
            {
                UsuarioId = usuarioId,
                NomeArquivo = file.FileName,
                DataUpload = DateTime.Now,
                StatusProcessamento = "Processando"
            };

            await _uow.Extratos.AddAsync(extrato);
            await _uow.CommitAsync(); // Salva o extrato para obter o ID

            var transacoes = new List<Transacao>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                // Pular cabeçalho se houver
                // var header = await reader.ReadLineAsync(); 

                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    // Assumindo que o CSV usa vírgula como separador
                    var data = line.Split(',');

                    try
                    {
                        var transacao = _transacaoFactory.CreateTransacao(data);
                        transacao.UsuarioId = usuarioId;
                        transacao.ExtratoId = extrato.Id;

                        // Aplica a estratégia de categorização (usando a de CNPJ como principal)
                        _categorizacaoContext.SetStrategy(new CategoriaCnpjStrategy(_uow));
                        await _categorizacaoContext.CategorizarTransacaoAsync(transacao);

                        transacoes.Add(transacao);
                    }
                    catch (Exception ex)
                    {
                        // Logar erro ou ignorar linha inválida
                        Console.WriteLine($"Erro ao processar linha: {line}. Erro: {ex.Message}");
                    }
                }
            }

            // Adicionar todas as transações de uma vez
            foreach (var transacao in transacoes)
            {
                await _uow.Transacoes.AddAsync(transacao);
            }

            extrato.StatusProcessamento = "Concluído";
            _uow.Extratos.Update(extrato);
            await _uow.CommitAsync();

            // Notificar Observers após o commit
            foreach (var transacao in transacoes)
            {
                await _transacaoSubject.Notify(transacao);
            }

            // O CommitAsync para as alterações dos Observers (vidas, conquistas)
            // deve ser feito no final do Service, se necessário.
            // Como os Observers usam o mesmo UoW, um único commit final é suficiente.
            await _uow.CommitAsync();

            return extrato;
        }
    }
}
