using GestionCitasAPI.Application.DTOs.Clientes;
using GestionCitasAPI.Domain.Entities;

namespace GestionCitasAPI.Application.Interfaces.Clientes
{
    public interface IClientesService
    {
        Task<IEnumerable<ClientesDto>> GetAllAsync();
        Task<ClientesDto> GetByIdAsync(int id);
        Task<ClientesDto> GetByDNIAsync(string dni);
        Task<ClientesDto> GetByTelefonoAsync(string telefono);

        Task<ClientesDto> CreateAsync(CreateClienteDto dto);
        Task<bool> UpdateAsync(int id, UpdateClienteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
