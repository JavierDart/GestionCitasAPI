using System.ComponentModel.DataAnnotations;

namespace GestionCitasAPI.Application.DTOs.Pagos
{
    public class UpdatePagoDto
    {
        public int CitaId { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
    }
}
