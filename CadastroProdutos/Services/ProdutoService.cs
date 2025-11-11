using CadastroProdutos.Models;
using CadastroProdutos.Repositories;
using System.Globalization;

namespace CadastroProdutos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public Produto Criar(string nome, decimal preco, int quantidade)
        {
            // Validações de domínio
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");
            if (preco < 0)
                throw new ArgumentException("Preço não pode ser negativo.");
            if (quantidade < 0)
                throw new ArgumentException("Quantidade não pode ser negativa.");
            if (_repo.ExistsByName(nome))
                throw new InvalidOperationException("Já existe um produto com esse nome.");

            var produto = new Produto
            {
                Nome = nome.Trim(),
                Preco = decimal.Round(preco, 2, MidpointRounding.ToEven),
                Quantidade = quantidade
            };
            return _repo.Add(produto);
        }

        public IEnumerable<Produto> Listar() => _repo.GetAll();

        public Produto? Obter(int id) => _repo.GetById(id);

        public bool Remover(int id) => _repo.Delete(id);

        public bool AtualizarPreco(int id, decimal novoPreco)
        {
            if (novoPreco < 0) return false;
            var p = _repo.GetById(id);
            if (p is null) return false;
            p.Preco = decimal.Round(novoPreco, 2, MidpointRounding.ToEven);
            _repo.Update(p);
            return true;
        }

        public bool AtualizarQuantidade(int id, int novaQuantidade)
        {
            if (novaQuantidade < 0) return false;
            var p = _repo.GetById(id);
            if (p is null) return false;
            p.Quantidade = novaQuantidade;
            _repo.Update(p);
            return true;
        }
    }
}
