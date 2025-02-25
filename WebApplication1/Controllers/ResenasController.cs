using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Services;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResenasController : ControllerBase
    {
        private readonly ResenaService _resenaService;
        private readonly RestauranteService _restauranteService;
        private readonly UsuarioService _usuarioService;

        public ResenasController(ResenaService resenaService, RestauranteService restauranteService, UsuarioService usuarioService)
        {
            _resenaService = resenaService;
            _restauranteService = restauranteService;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Resena>> GetResenas()
        {
            return Ok(_resenaService.GetResenas());
        }

        [HttpGet("{id}")]
        public ActionResult<Resena> GetResena(int id)
        {
            var resena = _resenaService.GetResena(id);
            if (resena == null)
            {
                return NotFound();
            }
            return Ok(resena);
        }

        [HttpPost]
        public ActionResult<Resena> CreateResena([FromForm] CreateResenaRequest request)
        {
            // Verificar
            var restaurante = _restauranteService.GetRestaurante(request.RestauranteId);
            if (restaurante == null)
            {
                return BadRequest("El restaurante no existe");
            }

            // Verificar 
            var usuario = _usuarioService.GetUsuario(request.UsuarioId);
            if (usuario == null)
            {
                return BadRequest("El usuario no existe");
            }

            var resena = new Resena
            {
                RestauranteId = request.RestauranteId,
                UsuarioId = request.UsuarioId,
                Calificacion = request.Calificacion,
                Comentario = request.Comentario,
                Fecha = DateTime.Now
            };

            _resenaService.CreateResena(resena);
            return CreatedAtAction(nameof(GetResena), new { id = resena.Id }, resena);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateResena(int id, [FromForm] UpdateResenaRequest request)
        {
            var resena = _resenaService.GetResena(id);
            if (resena == null)
            {
                return NotFound();
            }
            resena.Calificacion = request.Calificacion;
            resena.Comentario = request.Comentario;
            _resenaService.UpdateResena(resena);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteResena(int id)
        {
            var resena = _resenaService.GetResena(id);
            if (resena == null)
            {
                return NotFound();
            }
            _resenaService.DeleteResena(id);
            return NoContent();
        }
    }
}
