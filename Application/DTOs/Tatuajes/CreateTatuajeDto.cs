using System.ComponentModel.DataAnnotations;

namespace GestionCitasAPI.Application.DTOs.Tatuajes
{
    public class CreateTatuajeDto
    {
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public string Tamanyo { get; set; }
        [Required]
        public decimal PrecioEstimado { get; set; }
        public string ImagenUrl { get; set; }
        [Required]
        public int DuracionEstimadaHoras { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
