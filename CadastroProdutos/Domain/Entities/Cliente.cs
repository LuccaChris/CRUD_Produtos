using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutos.Models
{
    public class Cliente : Pessoa
    {
       public int Id { get; set; }
        public List<Pedido> Pedidos { get; set; } = new();

        public Cliente(int id, string nome, string email) : base(nome, email)
        {
            Id = id;
        } 

        public void AdicionarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }
    }
}