using CatTatuajeEntity = GestionCitasAPI.Domain.Entities.CatTatuajes;
namespace GestionCitasAPI.Application.Interfaces.CatTatuajes
{
    public interface ICatTatuajesRepository
    {
        Task<IEnumerable<CatTatuajeEntity>> GetAllAsync();
        Task<CatTatuajeEntity> GetByIdAsync(int id);
        Task AddAsync(CatTatuajeEntity catTatuaje);
        Task UpdateAsync(CatTatuajeEntity catTatuaje);
        Task DeleteAsync(CatTatuajeEntity catTatuaje);
        Task SaveChangesAsync();
    }
}
