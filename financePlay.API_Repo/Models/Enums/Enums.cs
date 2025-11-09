
namespace financePlay.API.Models.Enums
{
    public enum NivelUsuario { INICIANTE, INTERMEDIARIO, AVANCADO, EXPERT }
    public enum StatusConta { ATIVA, INATIVA, SUSPENSA }
    public enum TipoTransacao { CREDITO, DEBITO }
    public enum ConfiabilidadeCategoria { ALTA, MEDIA, BAIXA }
    public enum TipoArquivo { CSV, XLS, XLSX, OFX, PDF }
    public enum StatusExtrato { PROCESSANDO, PROCESSADO, ERRO, REJEITADO }
}
