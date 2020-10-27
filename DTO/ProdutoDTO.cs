using System.ComponentModel.DataAnnotations;

namespace sistema_supermercado_mvc.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Nome do produto é obrigátorio!")]
        [StringLength(100, ErrorMessage="O nome do produto não pode ter mais de 100 caracteres!")]
        [MinLength(2, ErrorMessage="O nome do produto deve ter mais de 2 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Categoria do produto é obrigatório!")]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage="Fornecedor do produto é obrigatório!")]
        public int FornecedorID { get; set; }

        [Required(ErrorMessage="Preço de custo do produto é obrigatório!")]
        public float PrecoDeCusto { get; set; }

        [Required(ErrorMessage="Preço de venda do produto é obrigatório!")]
        public float PrecoDeVenda { get; set; }

        [Required(ErrorMessage="Medição do produto é obrigatória!")]
        [Range(0, 2, ErrorMessage="Medição inválida!")] // Delimitar os valores que podem ser colocados no campo    
        public int Medicao { get; set; }
    }
}