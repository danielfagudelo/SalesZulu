using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = " El Campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carateres")]

        public string Name { get; set; } = null!;
        public ICollection<State>? States { get; set; }

        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
