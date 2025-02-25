using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class UpdateRestauranteRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        [Required]
        public string Cocina { get; set; }
        [Required]
        public int Capacidad { get; set; }
    }
}
