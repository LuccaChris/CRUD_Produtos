using CadastroProdutos.Domain.Entities;

namespace CadastroProdutos.Domain.Interfaces
{
    public interface IProdutoService
    {
        Produto Criar(string nome, decimal preco, int quantidade);
        IEnumerable<Produto> Listar();
        Produto? Obter(int id);
        bool Remover(int id);
        bool AtualizarPreco(int id, decimal novoPreco);
        bool AtualizarQuantidade(int id, int novaQuantidade);
    }
}
