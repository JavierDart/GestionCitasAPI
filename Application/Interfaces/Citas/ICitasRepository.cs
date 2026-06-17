using CitasEntity = GestionCitasAPI.Domain.Entities.Citas;
namespace GestionCitasAPI.Application.Interfaces.Citas
{
    public interface ICitasRepository
    {
        Task<IEnumerable<CitasEntity>> GetAllAsync();
        Task<CitasEntity> GetByIdAsync(int id);
        Task<CitasEntity> GetByFechaCitaAsync(DateTime FechaCita);
        Task<CitasEntity> GetByArtistaIdAsync(int ArtistaId);
        Task<CitasEntity> GetByTatuajeIdAsync(int TatuajeId);
        Task<CitasEntity> GetByClienteIdAsync(int ClienteId);
        Task<CitasEntity> GetByEstadoAsync(string Estado);

        Task AddAsync(CitasEntity citas);
        Task UpdateAsync(CitasEntity citas);
        Task DeleteAsync(CitasEntity citas);

        Task SaveChangesAsync();
    }
}
