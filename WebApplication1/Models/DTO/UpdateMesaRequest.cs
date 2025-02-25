using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class UpdateMesaRequest
    {
        [Required]
        public int Capacidad { get; set; }
        [Required]
        public bool EstaDisponible { get; set; }
    }
}
