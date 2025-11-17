using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Entities
{
    public class Cliente : Pessoa
    {
       public int Id { get; set; }
        public List<Pedido> Pedidos { get; set; } = new();

        public Cliente(int id, string nome, int Cpf, string email) : base(nome, cpf, email)
        {
            Id = id;
        } 

        public void AdicionarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public override string ToString()
            => $"ID: {Id} | Nome: {Nome} | CPF: {CPF} | Email: {Email} | Pedidos: {Pedidos.Count}";


    }
}