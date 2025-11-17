using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CadastroProdutos.Domain.Interfaces;
using CadastroProdutos.Domain.Entities;



namespace CadastroProdutos.Controllers
{
    public class ClienteController
    {
        private readonly IClienteService _service;
        private readonly IClienteView _view;

        public ClienteController(IClienteService service, IClienteView view)
        {
            _service = service;
            _view = view;

            // Garante parsing amigável para PT-BR (vírgula como separador)
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");
        }
        public void Run()
        {
            while (true)
            {
                _view.MostrarMenuCliente();
                var op = _view.LerEntrada("Escolha uma opção");

                switch (op)
                {
                    case "1":
                        Cadastrar();
                        break;
                    case "2":
                        Listar();
                        break;
                    case "3":
                        Consultar();
                        break;
                    case "4":
                        AtualizarPreco();
                        break;
                    case "5":
                        AtualizarQuantidade();
                        break;
                    case "6":
                        Remover();
                        break;
                    case "0":
                        _view.MostrarMensagem("Saindo... Até mais!");
                        return;
                    default:
                        _view.MostrarErro("Opção inválida!");
                        break;
                }
                _view.Pausar();
                _view.Limpar();
            }
        }

        private void Cadastrar()
        {
            try{
            var nome = _view.LerEntrada("Nome do cliente");
            var cpfStr = _view.LerEntrada("CPF do cliente");
            var email = _view.LerEntrada("Email do cliente");
            if (!int.TryParse(cpfStr, out int cpf))
            {
                _view.MostrarErro("CPF deve ser um número válido.");
                return;
            }
            if (_service.ExistsByCpf(cpfStr))
            {
                _view.MostrarErro("Já existe um cliente cadastrado com este CPF.");
                return;
            }
            if (_service.ExistsByEmail(email))
            {
                _view.MostrarErro("Já existe um cliente cadastrado com este email.");
                return;
            }
            var c = _service.Criar(nome, cpf, email);
            _view.MostrarMensagem($"Cliente {c.Nome} cadastrado com sucesso.");
            }
            catch(Exception ex)
            {
                _view.MostrarErro($"Erro ao cadastrar cliente: {ex.Message}");
            }
            
        }
        
        private void Listar()
        {
            throw new NotImplementedException();
        }

        private void Consultar()
        {
            throw new NotImplementedException();
        }

        private void AtualizarPreco()
        {
            throw new NotImplementedException();
        }

        private void AtualizarQuantidade()
        {
            throw new NotImplementedException();
        }

        private void Remover()
        {
            throw new NotImplementedException();
        }
    }
}