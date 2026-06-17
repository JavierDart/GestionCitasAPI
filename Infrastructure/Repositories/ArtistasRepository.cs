using GestionCitasAPI.Application.Interfaces.Artistas;
using GestionCitasAPI.Domain.Entities;
using GestionCitasAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasAPI.Infrastructure.Repositories
{
    public class ArtistasRepository : IArtistasRepository
    {
        private readonly AppDbContext _context;

        public ArtistasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Artistas artistas)
        {
            await _context.Artistas.AddAsync(artistas);
        }

        public Task DeleteAsync(Artistas artistas)
        {
            _context.Artistas.Remove(artistas);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Artistas>> GetAllAsync()
        {
            return await _context.Artistas.ToListAsync();
        }

        public async Task<Artistas> GetByIdAsync(int id)
        {
            return await _context.Artistas.FindAsync(id);
        }

        public async Task<Artistas> GetByTelefonoAsync(string telefono)
        {
            return await _context.Artistas.FirstOrDefaultAsync(c => c.Telefono == telefono);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Artistas artistas)
        {
            _context.Artistas.Update(artistas);
            return Task.CompletedTask;
        }
    }
}
