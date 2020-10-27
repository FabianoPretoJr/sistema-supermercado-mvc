using System.ComponentModel.DataAnnotations; // NÂO ESQUECE

namespace sistema_supermercado_mvc.DTO
{
    public class CategoriaDTO
    {
        [Required] // DATA ANOTATIONS
        public int Id { get; set; }
        [Required(ErrorMessage="Nome de categoria é obrigatório!")]
        [StringLength(100, ErrorMessage="Nome de categoria muito grande, tente um menor!")]
        [MinLength(2, ErrorMessage="Nome de categoria muito pequeno, tente um com mais de dois caracteres!")]
        public string Nome { get; set; }
    }
}