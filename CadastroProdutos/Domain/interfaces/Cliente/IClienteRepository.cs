using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProdutos.Domain.Entities;

namespace CadastroProdutos.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente? GetById(int id);
        List<Cliente> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        bool Delete(int id);
        bool ExistsByCpf(int cpf);
        bool ExistsByEmail(string email);

        
    }
}