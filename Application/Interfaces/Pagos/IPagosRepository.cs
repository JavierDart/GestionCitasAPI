using PagosEntity = GestionCitasAPI.Domain.Entities.Pagos;

namespace GestionCitasAPI.Application.Interfaces.Pagos
{
    public interface IPagosRepository
    {
        Task<IEnumerable<PagosEntity>> GetAllAsync();
        Task<PagosEntity> GetByIdAsync(int id);
        Task<PagosEntity> GetByCitaIdAsync(int CitaId);
        Task<PagosEntity> GetByFechaPagoAsync(DateTime FechaPago);

        Task AddAsync(PagosEntity pago);
        Task UpdateAsync(PagosEntity pago);
        Task DeleteAsync(PagosEntity pago);

        Task SaveChangesAsync();
    }
}
