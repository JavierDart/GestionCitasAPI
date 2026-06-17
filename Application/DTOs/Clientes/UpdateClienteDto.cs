namespace GestionCitasAPI.Application.DTOs.Clientes
{
    public class UpdateClienteDto
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
    }
}
