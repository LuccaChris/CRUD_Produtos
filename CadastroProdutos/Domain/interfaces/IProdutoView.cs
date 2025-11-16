namespace CadastroProdutos.Domain.Interfaces
{
    public interface IProdutoView
    {
        void MostrarMenu();
        void MostrarMensagem(string mensagem);
        void MostrarErro(string erro);
        void MostrarLinha(string texto);
        string LerEntrada(string label);
        void Pausar();
        void Limpar();
    }
}
