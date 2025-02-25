using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class UpdateResenaRequest
    {
        [Required]
        public int Calificacion { get; set; }
        [Required]
        public string Comentario { get; set; }
    }
}
