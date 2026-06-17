using GestionCitasAPI.Application.Interfaces.Pagos;
using GestionCitasAPI.Domain.Entities;
using GestionCitasAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCitasAPI.Infrastructure.Repositories
{
    public class PagosRepository : IPagosRepository
    {
        private readonly AppDbContext _context;

        public PagosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pagos pago)
        {
            await _context.Pagos.AddAsync(pago);
        }

        public Task DeleteAsync(Pagos pago)
        {
            _context.Pagos.Remove(pago);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Pagos>> GetAllAsync()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pagos> GetByCitaIdAsync(int CitaId)
        {
            return await _context.Pagos.FirstOrDefaultAsync(c => c.CitaId == CitaId);
        }

        public async Task<Pagos> GetByFechaPagoAsync(DateTime FechaPago)
        {
            return await _context.Pagos.FirstOrDefaultAsync(c => c.FechaPago == FechaPago);
        }

        public async Task<Pagos> GetByIdAsync(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Pagos pago)
        {
            _context.Pagos.Update(pago);
            return Task.CompletedTask;
        }
    }
}
