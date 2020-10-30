using System;
using Microsoft.AspNetCore.Mvc;
using sistema_supermercado_mvc.Data;
using System.Linq;
using sistema_supermercado_mvc.DTO;

namespace sistema_supermercado_mvc.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categorias()
        {
            var categorias = database.Categorias.Where(cat => cat.Status == true).ToList();
            return View(categorias);
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria(int id)
        {
            var categoria = database.Categorias.First(cat => cat.Id == id);

            CategoriaDTO categoriaView = new CategoriaDTO();

            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;

            return View(categoriaView);
        }

        public IActionResult Fornecedores()
        {
            var fornecedores = database.Fornecedores.Where(forne => forne.Status == true).ToList();
            return View(fornecedores);
        }

        public IActionResult NovoFornecedor()
        {
            return View();
        }

        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = database.Fornecedores.First(forne => forne.Id == id);

            FornecedorDTO fornecedorView = new FornecedorDTO();

            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Nome = fornecedor.Nome;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Telefone = fornecedor.Telefone;

            return View(fornecedorView);
        }
        
        public IActionResult Produtos()
        {
            return View();
        }

        public IActionResult NovoProduto()
        {
            ViewBag.Categorias = database.Categorias.ToList(); // .Categorias é um nome que vc dá, pode ser qualquer um 
            // busca todas categorias no banco, salva em uma lista e passa pra ViewBag que vai pro formulário pra virar um select

            ViewBag.Fornecedores = database.Fornecedores.ToList();

            return View();
        }
    }
}