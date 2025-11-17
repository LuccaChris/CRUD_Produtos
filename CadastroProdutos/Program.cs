using CadastroProdutos.Controllers;
using CadastroProdutos.Application.services;
using CadastroProdutos.Infrastructure.Repositories;
using CadastroProdutos.Views;


var repo = new InMemoryProdutoRepository();
var service = new ProdutoService(repo);
var view = new ConsoleProdutoView();
var controller = new ProdutoController(service, view);

controller.Run();
