using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Interfaces
{
    public interface IBaseView
    {
        void MostrarMensagem(string mensagem);
        void MostrarErro(string erro);
        void MostrarLinha(string texto);
        string LerEntrada(string label); 
        void Pausar();
        void Limpar();
    }
}