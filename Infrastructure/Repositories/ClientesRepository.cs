using GestionCitasAPI.Domain.Entities;
using GestionCitasAPI.Application.Interfaces;
using GestionCitasAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasAPI.Infrastructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly AppDbContext _context;

        public ClientesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Clientes> GetByDNIAsync(string dni)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.DNI == dni);
        }

        public async Task<Clientes> GetByTelefonoAsync(string telefono)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Telefono == telefono);
        }

        public async Task AddAsync(Clientes cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public Task UpdateAsync(Clientes cliente)
        {
            _context.Clientes.Update(cliente);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Clientes cliente)
        {
            _context.Clientes.Remove(cliente);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
