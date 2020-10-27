using System;
using Microsoft.AspNetCore.Mvc;

namespace sistema_supermercado_mvc.Controllers
{
    public class GestaoController : Controller
    {
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
    }
}