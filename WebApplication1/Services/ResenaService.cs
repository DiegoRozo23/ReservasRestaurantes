using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class ResenaService
    {
        private readonly ApplicationDbContext _context;

        public ResenaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Resena> GetResenas()
        {
            return _context.Resenas.ToList();
        }

        public Resena GetResena(int id)
        {
            return _context.Resenas.FirstOrDefault(r => r.Id == id);
        }

        public Resena CreateResena(Resena resena)
        {
            var restaurante = _context.Restaurantes.Find(resena.RestauranteId);
            if (restaurante == null)
            {
                throw new Exception("Invalid RestauranteId");
            }

            var usuario = _context.Usuarios.Find(resena.UsuarioId);
            if (usuario == null)
            {
                throw new Exception("Invalid UsuarioId");
            }

            _context.Resenas.Add(resena);
            _context.SaveChanges();
            return resena;
        }


        public void UpdateResena(Resena resena)
        {
            _context.Resenas.Update(resena);
            _context.SaveChanges();
        }

        public void DeleteResena(int id)
        {
            var resena = _context.Resenas.FirstOrDefault(r => r.Id == id);
            if (resena != null)
            {
                _context.Resenas.Remove(resena);
                _context.SaveChanges();
            }
        }
    }
}
