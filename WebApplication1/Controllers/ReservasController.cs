using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Services;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        private readonly RestauranteService _restauranteService;
        private readonly UsuarioService _usuarioService;

        public ReservasController(ReservaService reservaService, RestauranteService restauranteService, UsuarioService usuarioService)
        {
            _reservaService = reservaService;
            _restauranteService = restauranteService;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reserva>> GetReservas()
        {
            return Ok(_reservaService.GetReservas());
        }

        [HttpGet("{id}")]
        public ActionResult<Reserva> GetReserva(int id)
        {
            var reserva = _reservaService.GetReserva(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public ActionResult<Reserva> CreateReserva([FromForm] CreateReservaRequest request)
        {
            // Verificar si el restaurante existe
            var restaurante = _restauranteService.GetRestaurante(request.RestauranteId);
            if (restaurante == null)
            {
                return BadRequest("El restaurante no existe");
            }

            // Verificar si el usuario existe
            var usuario = _usuarioService.GetUsuario(request.UsuarioId);
            if (usuario == null)
            {
                return BadRequest("El usuario no existe");
            }

            var reserva = new Reserva
            {
                RestauranteId = request.RestauranteId,
                UsuarioId = request.UsuarioId,
                FechaHoraReserva = request.FechaHoraReserva,
                NumeroDePersonas = request.NumeroDePersonas,
                PeticionesEspeciales = request.PeticionesEspeciales,
                Estado = EstadoReserva.Pendiente
            };
            _reservaService.CreateReserva(reserva);
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateReserva(int id, [FromForm] UpdateReservaRequest request)
        {
            var reserva = _reservaService.GetReserva(id);
            if (reserva == null)
            {
                return NotFound();
            }
            reserva.RestauranteId = request.RestauranteId;
            reserva.UsuarioId = request.UsuarioId;
            reserva.FechaHoraReserva = request.FechaHoraReserva;
            reserva.NumeroDePersonas = request.NumeroDePersonas;
            reserva.PeticionesEspeciales = request.PeticionesEspeciales;
            reserva.Estado = request.Estado;
            _reservaService.UpdateReserva(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReserva(int id)
        {
            var reserva = _reservaService.GetReserva(id);
            if (reserva == null)
            {
                return NotFound();
            }
            _reservaService.DeleteReserva(id);
            return NoContent();
        }
    }
}
