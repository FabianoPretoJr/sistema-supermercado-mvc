using System;
using Microsoft.AspNetCore.Mvc;
using sistema_supermercado_mvc.DTO;
using sistema_supermercado_mvc.Models;
using sistema_supermercado_mvc.Data;
using System.Linq;

namespace sistema_supermercado_mvc.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext database;
        public CategoriasController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO CategoriaTemporaria)
        {
            if (ModelState.IsValid) // Validar formulário usando o DTO
            {
                Categoria categoria = new Categoria();
                categoria.Nome = CategoriaTemporaria.Nome;
                categoria.Status = true;
                database.Categorias.Add(categoria);
                database.SaveChanges();

                return RedirectToAction("Categorias", "Gestao");
            }
            else
            {
                return View("../Gestao/NovaCategoria");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(CategoriaDTO categoriaTemporaria)
        {
            if (ModelState.IsValid)
            {
                var categoria = database.Categorias.First(cat => cat.Id == categoriaTemporaria.Id);
                categoria.Nome = categoriaTemporaria.Nome;
                database.SaveChanges();
                
                return RedirectToAction("Categorias","Gestao");
            }   
            else
            {
                return View("../Gestao/EditarCategoria");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var categoria = database.Categorias.First(cat => cat.Id == id);
                categoria.Status = false;
                database.SaveChanges();
            }

            return RedirectToAction("Categorias", "Gestao");
        }
    }
}