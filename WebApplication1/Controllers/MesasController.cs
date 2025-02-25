using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Services;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesasController : ControllerBase
    {
        private readonly MesaService _mesaService;
        private readonly RestauranteService _restauranteService;

        public MesasController(MesaService mesaService, RestauranteService restauranteService)
        {
            _mesaService = mesaService;
            _restauranteService = restauranteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mesa>> GetMesas()
        {
            return Ok(_mesaService.GetMesas());
        }

        [HttpGet("{id}")]
        public ActionResult<Mesa> GetMesa(int id)
        {
            var mesa = _mesaService.GetMesa(id);
            if (mesa == null)
            {
                return NotFound();
            }
            return Ok(mesa);
        }

        [HttpPost]
        public ActionResult<Mesa> CreateMesa([FromForm] CreateMesaRequest request)
        {
            // Verificar si el restaurante existe
            var restaurante = _restauranteService.GetRestaurante(request.RestauranteId);
            if (restaurante == null)
            {
                return BadRequest("El restaurante no existe");
            }

            var mesa = new Mesa
            {
                RestauranteId = request.RestauranteId,
                Capacidad = request.Capacidad,
                EstaDisponible = request.EstaDisponible
            };
            _mesaService.CreateMesa(mesa);
            return CreatedAtAction(nameof(GetMesa), new { id = mesa.Id }, mesa);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMesa(int id, [FromForm] UpdateMesaRequest request)
        {
            var mesa = _mesaService.GetMesa(id);
            if (mesa == null)
            {
                return NotFound();
            }
            mesa.Capacidad = request.Capacidad;
            mesa.EstaDisponible = request.EstaDisponible;
            _mesaService.UpdateMesa(mesa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMesa(int id)
        {
            var mesa = _mesaService.GetMesa(id);
            if (mesa == null)
            {
                return NotFound();
            }
            _mesaService.DeleteMesa(id);
            return NoContent();
        }
    }
}
