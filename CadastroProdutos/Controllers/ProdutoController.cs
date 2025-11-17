using CadastroProdutos.Domain.Interfaces;
using CadastroProdutos.Domain.Entities;
using System.Globalization;

namespace CadastroProdutos.Controllers
{
    public class ProdutoController
    {
        private readonly IProdutoService _service;
        private readonly IProdutoView _view;

        public ProdutoController(IProdutoService service, IProdutoView view)
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
                _view.MostrarMenuProduto();
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
            try
            {
                var nome = _view.LerEntrada("Nome");
                var precoStr = _view.LerEntrada("Preço (ex: 199,90)");
                var qtdStr = _view.LerEntrada("Quantidade (ex: 10)");

                if (!decimal.TryParse(precoStr, out var preco))
                {
                    _view.MostrarErro("Preço inválido.");
                    return;
                }
                if (!int.TryParse(qtdStr, out var quantidade))
                {
                    _view.MostrarErro("Quantidade inválida.");
                    return;
                }

                var p = _service.Criar(nome, preco, quantidade);
                _view.MostrarMensagem($"Produto cadastrado! {p}");
            }
            catch (Exception ex)
            {
                _view.MostrarErro($"Erro ao cadastrar: {ex.Message}");
            }
        }

        private void Listar()
        {
            var lista = _service.Listar().ToList();
            if (!lista.Any())
            {
                _view.MostrarMensagem("Nenhum produto cadastrado.");
                return;
            }
            _view.MostrarLinha("\n=== LISTA DE PRODUTOS ===");
            foreach (var p in lista)
                _view.MostrarLinha(p.ToString());
            var total = lista.Sum(p => p.ValorEmEstoque);
            _view.MostrarLinha($"--- Valor total em estoque: R${total:F2}");
        }

        private void Consultar()
        {
            var idStr = _view.LerEntrada("ID do produto");
            if (!int.TryParse(idStr, out var id))
            {
                _view.MostrarErro("ID inválido.");
                return;
            }
            var p = _service.Obter(id);
            _view.MostrarLinha(p is null ? "Produto não encontrado." : p.ToString());
        }

        private void AtualizarPreco()
        {
            var idStr = _view.LerEntrada("ID do produto");
            var precoStr = _view.LerEntrada("Novo preço (ex: 259,90)");
            if (!int.TryParse(idStr, out var id) || !decimal.TryParse(precoStr, out var preco))
            {
                _view.MostrarErro("Entrada inválida.");
                return;
            }
            var ok = _service.AtualizarPreco(id, preco);
            _view.MostrarMensagem(ok ? "Preço atualizado." : "Produto não encontrado ou preço inválido.");
        }

        private void AtualizarQuantidade()
        {
            var idStr = _view.LerEntrada("ID do produto");
            var qtdStr = _view.LerEntrada("Nova quantidade (ex: 5)");
            if (!int.TryParse(idStr, out var id) || !int.TryParse(qtdStr, out var qtd))
            {
                _view.MostrarErro("Entrada inválida.");
                return;
            }
            var ok = _service.AtualizarQuantidade(id, qtd);
            _view.MostrarMensagem(ok ? "Quantidade atualizada." : "Produto não encontrado ou quantidade inválida.");
        }

        private void Remover()
        {
            var idStr = _view.LerEntrada("ID do produto para remover");
            if (!int.TryParse(idStr, out var id))
            {
                _view.MostrarErro("ID inválido.");
                return;
            }
            var ok = _service.Remover(id);
            _view.MostrarMensagem(ok ? "Removido com sucesso." : "Produto não encontrado.");
        }
    }
}
