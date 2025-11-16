using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public decimal ValorEmEstoque => Preco * Quantidade;
        public override string ToString()
            => $"ID: {Id} | {Nome} | Preço: R${Preco:F2} | Qtd: {Quantidade} | Total: R${ValorEmEstoque:F2}";
    }
}