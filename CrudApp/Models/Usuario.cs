using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password obligatorio")]
        public string Password { get; set; } = string.Empty;
    }    
}