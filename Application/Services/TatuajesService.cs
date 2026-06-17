using GestionCitasAPI.Application.DTOs.Clientes;
using GestionCitasAPI.Application.DTOs.Tatuajes;
using GestionCitasAPI.Application.Interfaces.Tatuajes;
using GestionCitasAPI.Domain.Entities;
using System.Net;

namespace GestionCitasAPI.Application.Services
{
    public class TatuajesService : ITatuajesService
    {
        private readonly ITatuajesRepository _repo;

        public TatuajesService(ITatuajesRepository repo)
        {
            _repo = repo;
        }

        private TatuajesDto MapToDto(Tatuajes tatuajes)
        {
            return new TatuajesDto
            {
                Id = tatuajes.Id,
                Nombre = tatuajes.Nombre,
                Descripcion = tatuajes.Descripcion,
                Tamanyo = tatuajes.Tamanyo,
                PrecioEstimado = tatuajes.PrecioEstimado,
                ImagenUrl = tatuajes.ImagenUrl,
                DuracionEstimadaHoras = tatuajes.DuracionEstimadaHoras,
                FechaCreacion = tatuajes.FechaCreacion,
                CategoriaId = tatuajes.CategoriaId
            };
        }

        public async Task<TatuajesDto> CreateAsync(CreateTatuajeDto dto)
        {
            var tatuaje = new Tatuajes
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Tamanyo = dto.Tamanyo,
                PrecioEstimado = dto.PrecioEstimado,
                ImagenUrl = dto.ImagenUrl,
                DuracionEstimadaHoras = dto.DuracionEstimadaHoras,
                FechaCreacion = dto.FechaCreacion,
                CategoriaId = dto.CategoriaId
            };

            await _repo.AddAsync(tatuaje);
            await _repo.SaveChangesAsync();

            return MapToDto(tatuaje);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tatuaje = await _repo.GetByIdAsync(id);
            if (tatuaje == null) return false;

            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TatuajesDto>> GetAllAsync()
        {
            var tatuajes = await _repo.GetAllAsync();
            return tatuajes.Select(x => new TatuajesDto {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Tamanyo = x.Tamanyo,
                PrecioEstimado = x.PrecioEstimado,
                ImagenUrl = x.ImagenUrl,
                DuracionEstimadaHoras = x.DuracionEstimadaHoras,
                FechaCreacion = x.FechaCreacion,
                CategoriaId = x.CategoriaId
            });
        }

        public async Task<TatuajesDto> GetByFechaCreacionAsync(DateTime FechaCreacion)
        {
            var tatuaje = await _repo.GetByFechaCreacionAsync(FechaCreacion);
            if (tatuaje == null) return null;

            return MapToDto(tatuaje);
        }

        public async Task<TatuajesDto> GetByIdAsync(int id)
        {
            var tatuaje = await _repo.GetByIdAsync(id);
            if (tatuaje == null) return null;

            return MapToDto(tatuaje);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTatuajeDto dto)
        {
            var tatuaje = await _repo.GetByIdAsync(id);
            if(tatuaje == null) return false;

            tatuaje.Nombre = dto.Nombre;
            tatuaje.Descripcion = dto.Descripcion;
            tatuaje.PrecioEstimado = dto.PrecioEstimado;
            tatuaje.DuracionEstimadaHoras = dto.DuracionEstimadaHoras;
            tatuaje.Tamanyo = dto.Tamanyo;
            tatuaje.ImagenUrl = dto.ImagenUrl;
            tatuaje.FechaCreacion = dto.FechaCreacion;
            tatuaje.CategoriaId = dto.CategoriaId;

            await _repo.UpdateAsync(tatuaje);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<TatuajesDto> GetByCategoriaIdAsync(int CategoriaId)
        {
            var tatuaje = await _repo.GetByCategoriaIdAsync(CategoriaId);
            if (tatuaje == null) return null;

            return MapToDto(tatuaje);
        }
    }
}
