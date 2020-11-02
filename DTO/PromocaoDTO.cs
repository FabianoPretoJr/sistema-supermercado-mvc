using System.ComponentModel.DataAnnotations;

namespace sistema_supermercado_mvc.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo nome é obrigatório!")]
        [StringLength(100, ErrorMessage="100 caracteres no máximo!")]
        [MinLength(3, ErrorMessage="3 caracteres no mínomo!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo Produto é obrigatório!")]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage="Campo porcentagem é obrigatório!")]
        [Range(0, 100, ErrorMessage="Valores devem estar entre 0 e 100!")]
        public float Porcentagem { get; set; }
    }
}