using System;
using Microsoft.AspNetCore.Mvc;
using sistema_supermercado_mvc.Data;
using System.Linq;

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
            return View();
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult Fornecedores()
        {
            return View();
        }

        public IActionResult NovoFornecedor()
        {
            return View();
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