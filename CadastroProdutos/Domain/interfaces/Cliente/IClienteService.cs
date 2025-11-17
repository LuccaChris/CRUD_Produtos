using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProdutos.Domain.Entities;

namespace CadastroProdutos.Domain.Interfaces
{
    public interface IClienteService
    {
        Cliente Criar(string nome, int cpf, string email);
        List<Cliente> ObterTodos();
        Cliente? ObterPorId(int id);
        bool Remover(int id);
        Cliente Atualizar(int id, string nome, int cpf, string email);
        bool ExistsByCpf(string cpf);
        bool ExistsByEmail(string email);
    }
}