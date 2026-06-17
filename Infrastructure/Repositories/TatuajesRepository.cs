using GestionCitasAPI.Domain.Entities;
using GestionCitasAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GestionCitasAPI.Infrastructure.Repositories
{
    public class TatuajesRepository : ITatuajesRepository
    {
        private readonly AppDbContext _context;

        public TatuajesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tatuajes tatuaje)
        {
            await _context.Tatuajes.AddAsync(tatuaje);
        }

        public async Task DeleteAsync(int id)
        {
            var tatuaje = await _context.Tatuajes
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (tatuaje != null)
            {
               _context.Tatuajes.Remove(tatuaje);
            }

        }

        public async Task<IEnumerable<Tatuajes>> GetAllAsync()
        {
            return await _context.Tatuajes.ToListAsync();
        }

        public async Task<Tatuajes> GetByCategoriaIdAsync(int CategoriaId)
        {
            return await _context.Tatuajes.FirstOrDefaultAsync(c => c.CategoriaId == CategoriaId);
        }

        public async Task<Tatuajes> GetByFechaCreacionAsync(DateTime FechaCreacion)
        {
            return await _context.Tatuajes.FirstOrDefaultAsync(c => c.FechaCreacion == FechaCreacion);
        }

        public async Task<Tatuajes> GetByIdAsync(int id)
        {
            return await _context.Tatuajes.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Tatuajes tatuaje)
        {
            _context.Tatuajes.Update(tatuaje);
            return Task.CompletedTask;
        }
    }
}
