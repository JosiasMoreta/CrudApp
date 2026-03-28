using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{

    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
