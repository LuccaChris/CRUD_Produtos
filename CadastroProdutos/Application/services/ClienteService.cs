using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProdutos.Domain.Entities;
using CadastroProdutos.Domain.Interfaces;


namespace CadastroProdutos.Application.services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public Cliente Criar (string nome, int cpf, string email)
        {
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cliente não pode ser vazio.");
            if(_clienteRepository.ExistsByCpf(cpf))
                throw new ArgumentException("Já existe um cliente com este CPF.");
            if(_clienteRepository.ExistsByEmail(email))
                throw new ArgumentException("Já existe um cliente com este email.");

            var cliente = new Cliente(0, nome, cpf, email);

            _clienteRepository.Add(cliente);
            return cliente;
        }
        public List<Cliente> ObterTodos()
            => _clienteRepository.GetAll();
        public Cliente? ObterPorId(int id)
            => _clienteRepository.GetById(id);
        public bool Remover(int id)
            => _clienteRepository.Delete(id);
        public Cliente Atualizar(int id, string nome, int cpf, string email)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente is null)
                throw new ArgumentException("Cliente não encontrado.");

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cliente não pode ser vazio.");
            if (_clienteRepository.ExistsByCpf(cpf) && cliente.CPF != cpf)
                throw new ArgumentException("Já existe um cliente com este CPF.");
            if (_clienteRepository.ExistsByEmail(email) && !cliente.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Já existe um cliente com este email.");

            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.Email = email;

            _clienteRepository.Update(cliente);
            return cliente;
        }

    }
}