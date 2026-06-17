using System.ComponentModel.DataAnnotations;
namespace GestionCitasAPI.Application.DTOs.Artistas
{
    public class CreateArtistaDto
    {
        [Required]
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Teléfono inválido")]
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
    }
}
