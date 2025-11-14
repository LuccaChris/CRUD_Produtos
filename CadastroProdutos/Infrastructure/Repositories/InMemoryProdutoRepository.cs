using CadastroProdutos.Models;

namespace CadastroProdutos.Repositories
{
    public class InMemoryProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _db = new();
        private int _idSeq = 1;

        public Produto Add(Produto produto)
        {
            produto.Id = _idSeq++;
            _db.Add(produto);
            return produto;
        }

        public bool Delete(int id)
        {
            var p = _db.FirstOrDefault(x => x.Id == id);
            if (p is null) return false;
            _db.Remove(p);
            return true;
        }

        public IEnumerable<Produto> GetAll() => _db.OrderBy(p => p.Id);

        public Produto? GetById(int id) => _db.FirstOrDefault(p => p.Id == id);

        public void Update(Produto produto)
        {
            var idx = _db.FindIndex(p => p.Id == produto.Id);
            if (idx >= 0) _db[idx] = produto;
        }

        public bool ExistsByName(string nome)
            => _db.Any(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }
}
