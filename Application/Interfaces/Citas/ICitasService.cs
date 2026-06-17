using GestionCitasAPI.Application.DTOs.Citas;

namespace GestionCitasAPI.Application.Interfaces.Citas
{
    public interface ICitasService
    {
        Task<IEnumerable<CitasDto>> GetAllAsync();
        Task<CitasDto> GetByIdAsync(int id);
        Task<CitasDto> GetByFechaCitaAsync(DateTime FechaCita);
        Task<CitasDto> GetByArtistaIdAsync(int ArtistaId);
        Task<CitasDto> GetByTatuajeIdAsync(int TatuajeId);
        Task<CitasDto> GetByClienteIdAsync(int ClienteId);
        Task<CitasDto> GetByEstadoAsync(string Estado);


        Task<CitasDto> CreateAsync(CreateCitaDto dto);
        Task<bool> UpdateAsync(int id, UpdateCitaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
