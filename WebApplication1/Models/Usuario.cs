namespace WebApplication1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string NumeroTelefono { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Resena> Resenas { get; set; }
    }
}

