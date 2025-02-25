using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantesController : ControllerBase
    {
        private readonly RestauranteService _restauranteService;

        // Inyectamos el servicio mediante el constructor
        public RestaurantesController(RestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurante>> GetRestaurantes()
        {
            var restaurantes = _restauranteService.GetRestaurantes();
            return Ok(restaurantes);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurante> GetRestaurante(int id)
        {
            var restaurante = _restauranteService.GetRestaurante(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            return Ok(restaurante);
        }

        [HttpPost]
        public ActionResult<Restaurante> CreateRestaurante([FromForm] CreateRestauranteRequest request)
        {
            var restaurante = new Restaurante
            {
                // Si la base de datos tiene la columna Id configurada como identidad, no es necesario asignarla manualmente.
                Nombre = request.Nombre,
                Ubicacion = request.Ubicacion,
                Cocina = request.Cocina,
                Capacidad = request.Capacidad,
                Reservas = new List<Reserva>(),
                Mesas = new List<Mesa>(),
                Resenas = new List<Resena>()
            };

            restaurante = _restauranteService.CreateRestaurante(restaurante);
            return CreatedAtAction(nameof(GetRestaurante), new { id = restaurante.Id }, restaurante);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRestaurante(int id, [FromForm] UpdateRestauranteRequest request)
        {
            // Creamos un objeto con los datos actualizados
            var updatedRestaurante = new Restaurante
            {
                Nombre = request.Nombre,
                Ubicacion = request.Ubicacion,
                Cocina = request.Cocina,
                Capacidad = request.Capacidad
            };

            var resultado = _restauranteService.UpdateRestaurante(id, updatedRestaurante);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurante(int id)
        {
            var resultado = _restauranteService.DeleteRestaurante(id);
            if (!resultado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
