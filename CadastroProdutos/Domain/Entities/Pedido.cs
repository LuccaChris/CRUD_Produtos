using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProdutos.interfaces;

namespace CadastroProdutos.Models
{
    public class Pedido : IPedido
    {
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public List<Item> Itens { get; set; }

        public Pedido(int numero)
        {
            Numero = numero;
            Data = DateTime.Now;
        }
        public void AdicionarItem(Item item)
        {
            Itens.Add(item);
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (var item in Itens)
                total += item.Preco * item.Quantidade;
            return total;
        }
        public void FecharPedido()
        {
            Console.WriteLine($"Pedido{Numero} fechado em {Data} com total de R$ {CalcularTotal():F2}");
        }
    }
}