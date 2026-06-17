using GestionCitasAPI.Domain.Entities;
public interface ITatuajesRepository
{
    Task<IEnumerable<Tatuajes>> GetAllAsync();
    Task<Tatuajes> GetByIdAsync(int id);
    Task<Tatuajes> GetByFechaCreacionAsync(DateTime FechaCreacion);
    Task<Tatuajes> GetByCategoriaIdAsync(int CategoriaId);
    Task AddAsync(Tatuajes tatuaje);
    Task UpdateAsync(Tatuajes tatuaje);
    Task DeleteAsync(int id);

    Task SaveChangesAsync();
}

