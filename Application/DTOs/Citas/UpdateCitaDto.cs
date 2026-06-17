namespace GestionCitasAPI.Application.DTOs.Citas
{
    public class UpdateCitaDto
    {
        public int ClienteId { get; set; }
        public int TatuajeId { get; set; }
        public int ArtistaId { get; set; }
        public DateTime FechaCita { get; set; }
        public int Duracion { get; set; }
        public string Estado { get; set; }
        public decimal PrecioFinal { get; set; }
        public decimal AnticipoPagado { get; set; }
        public string Notas { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
