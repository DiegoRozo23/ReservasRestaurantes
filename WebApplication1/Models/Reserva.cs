namespace WebApplication1.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHoraReserva { get; set; }
        public int NumeroDePersonas { get; set; }
        public string PeticionesEspeciales { get; set; }
        public EstadoReserva Estado { get; set; }

        public Restaurante Restaurante { get; set; }
        public Usuario Usuario { get; set; }
    }

    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        Cancelada
    }
}
