using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class ProdCategory
    {
        public int Id { get; set; }

        [Display(Name = "Categoria del producto")]
        [Required(ErrorMessage = " El Campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tenermas de {1} carateres")]

        public string Name { get; set; } = null!;
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<Product>? Products { get; set; }

        public int ProductsNumber => Products == null ? 0 : Products.Count;
    }
}
