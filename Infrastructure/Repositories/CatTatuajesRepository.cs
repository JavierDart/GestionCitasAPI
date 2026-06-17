using GestionCitasAPI.Application.Interfaces.CatTatuajes;
using GestionCitasAPI.Domain.Entities;
using GestionCitasAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasAPI.Infrastructure.Repositories
{
    public class CatTatuajesRepository : ICatTatuajesRepository
    {
        private readonly AppDbContext _context;

        public CatTatuajesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CatTatuajes catTatuaje)
        {
            await _context.CatTatuajes.AddAsync(catTatuaje);
        }

        public Task DeleteAsync(CatTatuajes catTatuaje)
        {
            _context.CatTatuajes.Remove(catTatuaje);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<CatTatuajes>> GetAllAsync()
        {
            return await _context.CatTatuajes.ToListAsync();
        }

        public async Task<CatTatuajes> GetByIdAsync(int id)
        {
            return await _context.CatTatuajes.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(CatTatuajes catTatuaje)
        {
            _context.CatTatuajes.Update(catTatuaje);
            return Task.CompletedTask;
        }
    }
}
