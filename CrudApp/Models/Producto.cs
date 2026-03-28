using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }
    }
}
