using System;
using Microsoft.AspNetCore.Mvc;
using sistema_supermercado_mvc.Models;
using sistema_supermercado_mvc.Data;
using System.Linq;

namespace sistema_supermercado_mvc.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly ApplicationDbContext database;
        public EstoqueController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(Estoque estoque)
        {
            database.Estoques.Add(estoque);
            database.SaveChanges();
            
            return RedirectToAction("Estoque", "Gestao");
        }

        [HttpPost]
        public IActionResult Atualizar(Estoque estoqueTemp)
        {
            var estoque = database.Estoques.First(e => e.Id == estoqueTemp.Id);

            estoque.Produto = database.Produtos.First(p => p.Id == estoqueTemp.ProdutoId);
            estoque.Quantidade = estoqueTemp.Quantidade;

            database.SaveChanges();

            return RedirectToAction("Estoque", "Gestao");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var estoque = database.Estoques.First(e => e.Id == id);
                database.Estoques.Remove(estoque);
                database.SaveChanges();
            }

            return RedirectToAction("Estoque", "Gestao");
        }
    }
}