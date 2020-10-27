using System;
using Microsoft.AspNetCore.Mvc;
using sistema_supermercado_mvc.DTO;

namespace sistema_supermercado_mvc.Controllers
{
    public class CategoriasController : Controller
    {
        [HttpPost]
        public IActionResult Salvar(CategoriaDTO CategoriaTemporaria)
        {
            return Content("Oi");
        }
    }
}