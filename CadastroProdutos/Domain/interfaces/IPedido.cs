using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Interfaces
{
    public interface IPedido
    {
        void FecharPedido();
        double CalcularTotal();
    }
}