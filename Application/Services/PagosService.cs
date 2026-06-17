using GestionCitasAPI.Application.DTOs.Pagos;
using GestionCitasAPI.Application.Interfaces.Pagos;
using GestionCitasAPI.Domain.Entities;

namespace GestionCitasAPI.Application.Services
{
    public class PagosService : IPagosService
    {
        private readonly IPagosRepository _repo;

        public PagosService(IPagosRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagosDto> CreateAsync(CreatePagoDto dto)
        {
            var pago = new Pagos
            {
                CitaId = dto.CitaId,
                Cantidad = dto.Cantidad,
                FechaPago = dto.FechaPago,
                MetodoPago = dto.MetodoPago
            };

            await _repo.AddAsync(pago);
            await _repo.SaveChangesAsync();

            return MapToDto(pago);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pago = await _repo.GetByIdAsync(id);
            if (pago == null) return false;

            await _repo.DeleteAsync(pago);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PagosDto>> GetAllAsync()
        {
            var pagos = await _repo.GetAllAsync();
            return pagos.Select(x => new PagosDto
            {
                Id = x.Id,
                CitaId = x.CitaId,
                Cantidad = x.Cantidad,
                FechaPago = x.FechaPago,
                MetodoPago= x.MetodoPago
            });
        }

        public async Task<PagosDto> GetByCitaIdAsync(int CitaId)
        {
            var pago = await _repo.GetByCitaIdAsync(CitaId);
            if (pago == null) return null;

            return MapToDto(pago);
        }

        public async Task<PagosDto> GetByFechaPagoAsync(DateTime FechaPago)
        {
            var pago = await _repo.GetByFechaPagoAsync(FechaPago);
            if (pago == null) return null;

            return MapToDto(pago);
        }

        public async Task<PagosDto> GetByIdAsync(int id)
        {
            var pago = await _repo.GetByIdAsync(id);
            if (pago == null) return null;

            return MapToDto(pago);
        }

        public async Task<bool> UpdateAsync(int id, UpdatePagoDto dto)
        {
            var pago = await _repo.GetByIdAsync(id);
            if(pago == null) return false;

            pago.CitaId = dto.CitaId;
            pago.Cantidad = dto.Cantidad;
            pago.FechaPago = dto.FechaPago;
            pago.MetodoPago = dto.MetodoPago;

            await _repo.UpdateAsync(pago);
            await _repo.SaveChangesAsync();

            return true;
        }

        private PagosDto MapToDto(Pagos pago)
        {
            return new PagosDto
            {
                Id = pago.Id,
                CitaId = pago.CitaId,
                FechaPago = pago.FechaPago,
                Cantidad = pago.Cantidad,
                MetodoPago = pago.MetodoPago
            };
        }
    }
}
