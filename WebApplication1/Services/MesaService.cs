using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class MesaService
    {
        private readonly ApplicationDbContext _context;

        public MesaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Mesa> GetMesas()
        {
            return _context.Mesas.ToList();
        }

        public Mesa GetMesa(int id)
        {
            return _context.Mesas.FirstOrDefault(m => m.Id == id);
        }

        public Mesa CreateMesa(Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
            return mesa;
        }

        public void UpdateMesa(Mesa mesa)
        {
            _context.Mesas.Update(mesa);
            _context.SaveChanges();
        }

        public void DeleteMesa(int id)
        {
            var mesa = _context.Mesas.FirstOrDefault(m => m.Id == id);
            if (mesa != null)
            {
                _context.Mesas.Remove(mesa);
                _context.SaveChanges();
            }
        }
    }
}
