using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class CategoriaModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public int nIdCategori { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string? cNombCateg { get; set; }
        public bool cEsActiva { get; set; }
    }
}
