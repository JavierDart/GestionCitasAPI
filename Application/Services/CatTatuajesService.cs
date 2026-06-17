using GestionCitasAPI.Application.DTOs.CatTatuajes;
using GestionCitasAPI.Application.Interfaces.CatTatuajes;
using GestionCitasAPI.Domain.Entities;

namespace GestionCitasAPI.Application.Services
{
    public class CatTatuajesService : ICatTatuajesService
    {
        public readonly ICatTatuajesRepository _repo;

        public CatTatuajesService(ICatTatuajesRepository repo)
        {
            _repo = repo;
        }

        public async Task<CatTatuajeDto> CreateAsync(CreateCatTatuajeDto dto)
        {
            var categoria = new CatTatuajes
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            await _repo.AddAsync(categoria);
            await _repo.SaveChangesAsync();

            return MapToDto(categoria);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _repo.GetByIdAsync(id);
            if (categoria == null) return false;

            await _repo.DeleteAsync(categoria);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CatTatuajeDto>> GetAllAsync()
        {
            var categoria = await _repo.GetAllAsync();
            return categoria.Select(x => new CatTatuajeDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            });
        }

        public async Task<CatTatuajeDto> GetByIdAsync(int id)
        {
            var categoria = await _repo.GetByIdAsync(id);
            if (categoria == null) return null;

            return MapToDto(categoria);
        }

        public async Task<bool> UpdateAsync(int id, UpdateCatTatuajeDto dto)
        {
            var categoria = await _repo.GetByIdAsync(id);
            if (categoria == null) return false;

            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;

            await _repo.UpdateAsync(categoria);
            await _repo.SaveChangesAsync();

            return true;
        }

        private CatTatuajeDto MapToDto(CatTatuajes catTatuajes)
        {
            return new CatTatuajeDto
            {
                Id = catTatuajes.Id,
                Nombre = catTatuajes.Nombre,
                Descripcion = catTatuajes.Descripcion
            };
        }
    }
}
