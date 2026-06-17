using ArtistaEntity = GestionCitasAPI.Domain.Entities.Artistas;

namespace GestionCitasAPI.Application.Interfaces.Artistas
{
    public interface IArtistasRepository
    {
        Task<IEnumerable<ArtistaEntity>> GetAllAsync();
        Task<ArtistaEntity> GetByIdAsync(int id);
        Task<ArtistaEntity> GetByTelefonoAsync(string telefono);
        Task AddAsync(ArtistaEntity artistas);
        Task UpdateAsync(ArtistaEntity artistas);
        Task DeleteAsync(ArtistaEntity artistas);

        Task SaveChangesAsync();
    }
}
