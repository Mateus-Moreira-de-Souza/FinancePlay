﻿namespace financePlay.API.DTOs
{
    public class RegisterDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; } // CPF em texto plano, será hasheado
    }
}
