namespace WebApplication1.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Cocina { get; set; }
        public int Capacidad { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Mesa> Mesas { get; set; }
        public List<Resena> Resenas { get; set; }
    }
}
