namespace WebApplication1.Models
{
    public class Resena
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public int UsuarioId { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public Restaurante Restaurante { get; set; }
        public Usuario Usuario { get; set; }
    }
}
