using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreateUsuarioRequest
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        public string NumeroTelefono { get; set; }
    }
}
