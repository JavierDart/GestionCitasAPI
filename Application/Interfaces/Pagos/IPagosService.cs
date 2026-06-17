using GestionCitasAPI.Application.DTOs.Pagos;

namespace GestionCitasAPI.Application.Interfaces.Pagos
{
    public interface IPagosService
    {
        Task<IEnumerable<PagosDto>> GetAllAsync();
        Task<PagosDto> GetByIdAsync(int id);
        Task<PagosDto> GetByCitaIdAsync(int CitaId);
        Task<PagosDto> GetByFechaPagoAsync(DateTime FechaPago);

        Task<PagosDto> CreateAsync(CreatePagoDto dto);
        Task<bool> UpdateAsync(int id, UpdatePagoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
