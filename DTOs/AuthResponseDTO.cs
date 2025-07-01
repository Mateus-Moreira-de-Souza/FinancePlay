namespace financePlay.API.DTOs
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Vidas { get; set; }
    }
}
