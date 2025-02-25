using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class ReservaService
    {
        private readonly ApplicationDbContext _context;

        public ReservaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reserva> GetReservas()
        {
            return _context.Reservas.ToList();
        }

        public Reserva GetReserva(int id)
        {
            return _context.Reservas.FirstOrDefault(r => r.Id == id);
        }

        public Reserva CreateReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
            return reserva;
        }

        public void UpdateReserva(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            _context.SaveChanges();
        }

        public void DeleteReserva(int id)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
        }
    }
}
