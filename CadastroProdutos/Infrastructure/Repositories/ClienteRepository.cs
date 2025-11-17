using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProdutos.Domain.Entities;
using CadastroProdutos.Domain.Interfaces;

namespace CadastroProdutos.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _db = new();
        private int _idSeq = 1; 

        public void Add(Cliente cliente)
        {
            cliente.Id = _idSeq++;
            _db.Add(cliente);
        }
        public bool Delete(int id)
        {
            var c = _db.FirstOrDefault(x => x.Id == id);
            if (c is null) return false;
            _db.Remove(c);
            return true;
        }
        public List<Cliente> GetAll() => _db.OrderBy(c => c.Id).ToList();
        public Cliente? GetById(int id) => _db.FirstOrDefault(c => c.Id == id);
        public void Update(Cliente cliente)
        {
            var idx = _db.FindIndex(c => c.Id == cliente.Id);
            if (idx >= 0) _db[idx] = cliente;
        }
        public bool ExistsByCpf(int cpf)
            => _db.Any(c => c.CPF == cpf);
        public bool ExistsByEmail(string email)
         => _db.Any(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}