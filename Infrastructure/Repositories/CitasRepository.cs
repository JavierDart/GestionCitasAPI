using GestionCitasAPI.Application.Interfaces.Citas;
using GestionCitasAPI.Domain.Entities;
using GestionCitasAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasAPI.Infrastructure.Repositories
{
    public class CitasRepository : ICitasRepository
    {
        private readonly AppDbContext _context;

        public CitasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Citas citas)
        {
            await _context.Citas.AddAsync(citas);
        }

        public Task DeleteAsync(Citas citas)
        {
            _context.Citas.Remove(citas);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Citas>> GetAllAsync()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Citas> GetByArtistaIdAsync(int ArtistaId)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.ArtistaId == ArtistaId);
        }

        public async Task<Citas> GetByClienteIdAsync(int ClienteId)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.ClienteId == ClienteId);
        }

        public async Task<Citas> GetByEstadoAsync(string Estado)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.Estado == Estado);
        }

        public async Task<Citas> GetByFechaCitaAsync(DateTime FechaCita)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.FechaCita == FechaCita);
        }

        public async Task<Citas> GetByIdAsync(int id)
        {
            return await _context.Citas.FindAsync(id);
        }

        public async Task<Citas> GetByTatuajeIdAsync(int TatuajeId)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.TatuajeId == TatuajeId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Citas citas)
        {
            _context.Citas.Update(citas);
            return Task.CompletedTask;
        }
    }
}
