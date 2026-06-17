namespace GestionCitasAPI.Application.DTOs.Tatuajes
{
    public class TatuajesDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tamanyo { get; set; }
        public decimal PrecioEstimado { get; set; }
        public string ImagenUrl { get; set; }
        public int DuracionEstimadaHoras { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaId { get; set; }
    }
}
