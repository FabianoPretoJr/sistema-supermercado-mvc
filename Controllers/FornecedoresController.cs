using System;
using Microsoft.AspNetCore.Mvc;
using sistema_supermercado_mvc.Models;
using sistema_supermercado_mvc.DTO;
using sistema_supermercado_mvc.Data;

namespace sistema_supermercado_mvc.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext database;
        public FornecedoresController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO fornecedorTemporario)
        {
            if (ModelState.IsValid)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = fornecedorTemporario.Nome;
                fornecedor.Email = fornecedorTemporario.Email;
                fornecedor.Telefone = fornecedorTemporario.Telefone;
                fornecedor.Status = true;
                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }   
            else
            {
                return View("../Gestao/NovoFornecedor");
            }
        }
    }
}