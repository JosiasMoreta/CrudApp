using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Range(1, 10000, ErrorMessage = "Precio inválido")]
        public decimal Precio { get; set; }


    }
}
