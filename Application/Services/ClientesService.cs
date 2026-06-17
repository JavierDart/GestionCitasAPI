using GestionCitasAPI.Application.DTOs.Clientes;
using GestionCitasAPI.Application.Interfaces.Clientes;
using GestionCitasAPI.Domain.Entities;

namespace GestionCitasAPI.Application.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _repo;

        public ClientesService(IClientesRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ClientesDto>> GetAllAsync()
        {
            var clientes = await _repo.GetAllAsync();

            return clientes.Select(x => new ClientesDto
            {
                Id = x.Id,
                DNI = x.DNI,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                FechaNacimiento = x.FechaNacimiento,
                Email = x.Email,
                Telefono = x.Telefono,
                FechaRegistro = x.FechaRegistro,
                Observaciones = x.Observaciones
            });
        }

        public async Task<ClientesDto> GetByIdAsync(int id)
        {
            var cliente = await _repo.GetByIdAsync(id);
            if (cliente == null) return null;

            return MapToDto(cliente);
        }

        public async Task<ClientesDto> GetByDNIAsync(string dni)
        {
            var cliente = await _repo.GetByDNIAsync(dni);
            if (cliente == null) return null;

            return MapToDto(cliente);
        }

        public async Task<ClientesDto> GetByTelefonoAsync(string telefono)
        {
            var cliente = await _repo.GetByTelefonoAsync(telefono);
            if (cliente == null) return null;

            return MapToDto(cliente);
        }

        public async Task<ClientesDto> CreateAsync(CreateClienteDto dto)
        {
            var cliente = new Clientes
            {
                DNI = dto.DNI,
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                FechaNacimiento = dto.FechaNacimiento,
                Email = dto.Email,
                Telefono = dto.Telefono,
                Observaciones = dto.Observaciones,
                FechaRegistro = DateTime.Now // o BD
            };

            await _repo.AddAsync(cliente);
            await _repo.SaveChangesAsync();

            return MapToDto(cliente);
        }

        public async Task<bool> UpdateAsync(int id, UpdateClienteDto dto)
        {
            var cliente = await _repo.GetByIdAsync(id);
            if (cliente == null) return false;

            cliente.DNI = dto.DNI;
            cliente.Nombre = dto.Nombre;
            cliente.Apellidos = dto.Apellidos;
            cliente.FechaNacimiento = dto.FechaNacimiento;
            cliente.Email = dto.Email;
            cliente.Telefono = dto.Telefono;
            cliente.Observaciones = dto.Observaciones;

            await _repo.UpdateAsync(cliente);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _repo.GetByIdAsync(id);
            if (cliente == null) return false;

            await _repo.DeleteAsync(cliente);
            await _repo.SaveChangesAsync();

            return true;
        }

        private ClientesDto MapToDto(Clientes cliente)
        {
            return new ClientesDto
            {
                Id = cliente.Id,
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                FechaNacimiento = cliente.FechaNacimiento,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                FechaRegistro = cliente.FechaRegistro,
                Observaciones = cliente.Observaciones
            };
        }
    }
}
