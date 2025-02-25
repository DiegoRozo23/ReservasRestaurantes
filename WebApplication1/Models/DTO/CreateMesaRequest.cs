using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class CreateMesaRequest
    {
        [Required]
        public int RestauranteId { get; set; }
        [Required]
        public int Capacidad { get; set; }
        [Required]
        public bool EstaDisponible { get; set; }
    }
}
