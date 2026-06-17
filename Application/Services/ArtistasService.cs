using GestionCitasAPI.Application.DTOs.Artistas;
using GestionCitasAPI.Application.Interfaces.Artistas;
using GestionCitasAPI.Domain.Entities;

namespace GestionCitasAPI.Application.Services
{
    public class ArtistasService : IArtistasService
    {
        private readonly IArtistasRepository _repo;

        public ArtistasService(IArtistasRepository repo)
        {
            _repo = repo;
        }

        public async Task<ArtistasDto> CreateAsync(CreateArtistaDto dto)
        {
            var artista = new Artistas
            {
                NombreCompleto = dto.NombreCompleto,
                Especialidad = dto.Especialidad,
                Telefono = dto.Telefono,
                Observaciones = dto.Observaciones
            };

            await _repo.AddAsync(artista);
            await _repo.SaveChangesAsync();

            return MapToDto(artista);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var artista = await _repo.GetByIdAsync(id);
            if (artista == null) return false;

            await _repo.DeleteAsync(artista);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ArtistasDto>> GetAllAsync()
        {
            var artistas = await _repo.GetAllAsync();
            return artistas.Select(x => new ArtistasDto
            {
                Id = x.Id,
                NombreCompleto = x.NombreCompleto,
                Especialidad = x.Especialidad,
                Telefono = x.Telefono,
                Observaciones = x.Observaciones
            });
        }

        public async Task<ArtistasDto> GetByIdAsync(int id)
        {
            var artista = await _repo.GetByIdAsync(id);
            if (artista == null) return null;

            return MapToDto(artista);
        }

        public async Task<ArtistasDto> GetByTelefonoAsync(string telefono)
        {
            var artista = await _repo.GetByTelefonoAsync(telefono);
            if (artista == null) return null;

            return MapToDto(artista);
        }

        public async Task<bool> UpdateAsync(int id, UpdateArtistaDto dto)
        {
            var artista = await _repo.GetByIdAsync(id);
            if(artista == null) return false;

            artista.NombreCompleto = dto.NombreCompleto;
            artista.Especialidad = dto.Especialidad;
            artista.Telefono = dto.Telefono;
            artista.Observaciones = dto.Observaciones;

            await _repo.UpdateAsync(artista);
            await _repo.SaveChangesAsync();

            return true;
        }

        private ArtistasDto MapToDto(Artistas artistas)
        {
            return new ArtistasDto
            {
                Id = artistas.Id,
                NombreCompleto = artistas.NombreCompleto,
                Especialidad = artistas.Especialidad,
                Telefono = artistas.Telefono,
                Observaciones = artistas.Observaciones
            };
        }
    }
}
