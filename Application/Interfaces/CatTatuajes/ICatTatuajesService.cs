using GestionCitasAPI.Application.DTOs.CatTatuajes;

namespace GestionCitasAPI.Application.Interfaces.CatTatuajes
{
    public interface ICatTatuajesService
    {
        Task<IEnumerable<CatTatuajeDto>> GetAllAsync();
        Task<CatTatuajeDto> GetByIdAsync(int id);
        Task<CatTatuajeDto> CreateAsync(CreateCatTatuajeDto dto);
        Task<bool> UpdateAsync(int id, UpdateCatTatuajeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
