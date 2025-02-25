using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class CreateResenaRequest
    {
        [Required]
        public int RestauranteId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int Calificacion { get; set; }
        [Required]
        public string Comentario { get; set; }
    }
}
