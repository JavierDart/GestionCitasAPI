namespace GestionCitasAPI.Application.DTOs.Pagos
{
    public class PagosDto
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
    }
}
