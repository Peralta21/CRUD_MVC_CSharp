using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class ProductoModel
    {
        public int nIdProduct { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string? cNombProdu { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int? nPrecioProd { get; set; }
        public int nIdCategori { get; set; }
        public string? cNombCateg { get; set; }
    }
}
