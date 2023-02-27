using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = " El Campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tenermas de {1} carateres")]

        public string Name { get; set; } = null!;

        public ICollection<ProdCategory>? ProdCategories { get; set; }
    }
}
