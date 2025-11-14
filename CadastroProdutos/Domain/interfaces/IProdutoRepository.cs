using CadastroProdutos.Models;

namespace CadastroProdutos.Repositories
{
    public interface IProdutoRepository
    {
        Produto? GetById(int id);
        IEnumerable<Produto> GetAll();
        Produto Add(Produto produto);
        void Update(Produto produto);
        bool Delete(int id);
        bool ExistsByName(string nome);
    }
}
