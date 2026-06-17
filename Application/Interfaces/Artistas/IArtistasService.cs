using GestionCitasAPI.Application.DTOs.Artistas;

namespace GestionCitasAPI.Application.Interfaces.Artistas
{
    public interface IArtistasService
    {
        Task<IEnumerable<ArtistasDto>> GetAllAsync();
        Task<ArtistasDto> GetByIdAsync(int id);
        Task<ArtistasDto> GetByTelefonoAsync(string telefono);

        Task<ArtistasDto> CreateAsync(CreateArtistaDto dto);
        Task<bool> UpdateAsync(int id, UpdateArtistaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
