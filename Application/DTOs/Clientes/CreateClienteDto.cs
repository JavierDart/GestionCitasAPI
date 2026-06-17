using System.ComponentModel.DataAnnotations;

namespace GestionCitasAPI.Application.DTOs.Clientes
{
    
    public class CreateClienteDto
    {
        [RegularExpression(@"^\d{8}[A-Za-z]$", ErrorMessage = "DNI inválido")]
        public string? DNI { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Teléfono inválido")]
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
    }
}
