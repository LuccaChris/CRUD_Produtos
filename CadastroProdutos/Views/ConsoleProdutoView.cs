using CadastroProdutos.Domain.Interfaces;
namespace CadastroProdutos.Views
{
    public class ConsoleProdutoView : IProdutoView
    {
        string divisor = " ===========================";
        public void MostrarMenu()
        {
            Console.WriteLine("\n|CLLA| CADASTRO DE PRODUTOS |");
            Console.WriteLine(divisor);
            Console.WriteLine("| 1 - Cadastrar produto     |");
            Console.WriteLine("| 2 - Listar produtos       |");
            Console.WriteLine("| 3 - Consultar por ID      |");
            Console.WriteLine("| 4 - Atualizar preço       |");
            Console.WriteLine("| 5 - Atualizar quantidade  |");
            Console.WriteLine("| 6 - Remover produto       |");
            Console.WriteLine("| 0 - Sair                  |");
        }

        public void MostrarMensagem(string mensagem) => Console.WriteLine(mensagem);

        public void MostrarErro(string erro)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erro);
            Console.ForegroundColor = old;
        }

        public void MostrarLinha(string texto) => Console.WriteLine(texto);

        public string LerEntrada(string label)
        {
            Console.Write($"{label}: ");
            return Console.ReadLine() ?? string.Empty;
        }

        public void Pausar()
        {
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }

        public void Limpar() => Console.Clear();
    }
}