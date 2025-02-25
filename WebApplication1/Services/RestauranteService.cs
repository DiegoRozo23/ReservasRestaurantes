using WebApplication1.Models;
using WebApplication1.Data;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class RestauranteService
    {
        private readonly ApplicationDbContext _context;

        public RestauranteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurante> GetRestaurantes()
        {
            return _context.Restaurantes.ToList();
        }

        public Restaurante GetRestaurante(int id)
        {
            return _context.Restaurantes.FirstOrDefault(r => r.Id == id);
        }

        public Restaurante CreateRestaurante(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
            return restaurante;
        }

        public bool UpdateRestaurante(int id, Restaurante updatedRestaurante)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(r => r.Id == id);
            if (restaurante == null)
            {
                return false;
            }
            restaurante.Nombre = updatedRestaurante.Nombre;
            restaurante.Ubicacion = updatedRestaurante.Ubicacion;
            restaurante.Cocina = updatedRestaurante.Cocina;
            restaurante.Capacidad = updatedRestaurante.Capacidad;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteRestaurante(int id)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(r => r.Id == id);
            if (restaurante == null)
            {
                return false;
            }
            _context.Restaurantes.Remove(restaurante);
            _context.SaveChanges();
            return true;
        }
    }
}
