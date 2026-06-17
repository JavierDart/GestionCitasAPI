using GestionCitasAPI.Domain.Entities;

public interface IClientesRepository
{
    Task<IEnumerable<Clientes>> GetAllAsync();
    Task<Clientes> GetByIdAsync(int id);
    Task<Clientes> GetByDNIAsync(string dni);
    Task<Clientes> GetByTelefonoAsync(string telefono);

    Task AddAsync(Clientes cliente);
    Task UpdateAsync(Clientes cliente);
    Task DeleteAsync(Clientes cliente);

    Task SaveChangesAsync();
}
