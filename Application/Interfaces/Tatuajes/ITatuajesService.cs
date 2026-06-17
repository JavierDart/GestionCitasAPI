using GestionCitasAPI.Application.DTOs.Tatuajes;

namespace GestionCitasAPI.Application.Interfaces.Tatuajes
{
    public interface ITatuajesService
    {
        Task<IEnumerable<TatuajesDto>> GetAllAsync();
        Task<TatuajesDto> GetByIdAsync(int id);
        Task<TatuajesDto> GetByFechaCreacionAsync(DateTime FechaCreacion);
        Task<TatuajesDto> GetByCategoriaIdAsync(int CategoriaId);
        Task<TatuajesDto> CreateAsync(CreateTatuajeDto dto);
        Task<bool> UpdateAsync(int id, UpdateTatuajeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
