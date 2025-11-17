using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Entities
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public int CPF { get; set; }
        public string Email { get; set; }

        public Pessoa (string nome, int Cpf, string email)
        {
            Nome = nome;
            CPF = Cpf;
            Email = email;
        }
    }
}