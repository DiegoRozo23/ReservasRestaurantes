﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class CreateReservaRequest
    {
        [Required]
        public int RestauranteId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public DateTime FechaHoraReserva { get; set; }
        [Required]
        public int NumeroDePersonas { get; set; }
        public string PeticionesEspeciales { get; set; }
    }
}
