namespace WebApplication1.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public int Capacidad { get; set; }
        public bool EstaDisponible { get; set; }

        public Restaurante Restaurante { get; set; }
    }
}
