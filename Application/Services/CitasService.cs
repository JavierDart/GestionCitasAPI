using GestionCitasAPI.Application.DTOs.Citas;
using GestionCitasAPI.Application.Interfaces.Citas;
using GestionCitasAPI.Domain.Entities;

namespace GestionCitasAPI.Application.Services
{
    public class CitasService : ICitasService
    {
        private readonly ICitasRepository _repo;

        public CitasService(ICitasRepository repo)
        {
            _repo = repo;
        }

        public async Task<CitasDto> CreateAsync(CreateCitaDto dto)
        {
            var citas = new Citas
            {
                ClienteId = dto.ClienteId,
                TatuajeId = dto.TatuajeId,
                ArtistaId = dto.ArtistaId,
                FechaCita = dto.FechaCita,
                Duracion = dto.Duracion,
                Estado = "PENDIENTE",
                PrecioFinal = dto.PrecioFinal,
                AnticipoPagado = dto.AnticipoPagado,
                Notas = dto.Notas,
                FechaCreacion = DateTime.Now
            };

            await _repo.AddAsync(citas);
            await _repo.SaveChangesAsync();

            return MapToDto(citas);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _repo.GetByIdAsync(id);
            if (cita == null) return false;

            await _repo.DeleteAsync(cita);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CitasDto>> GetAllAsync()
        {
            var citas = await _repo.GetAllAsync();
            return citas.Select(x => new CitasDto
            {
                Id = x.Id,
                ClienteId = x.ClienteId,
                ArtistaId= x.ArtistaId,
                TatuajeId = x.TatuajeId,
                FechaCita = x.FechaCita,
                Duracion = x.Duracion,
                Estado = x.Estado,
                PrecioFinal = x.PrecioFinal,
                AnticipoPagado = x.AnticipoPagado,
                Notas = x.Notas
            });
        }

        public async Task<CitasDto> GetByArtistaIdAsync(int ArtistaId)
        {
            var cita = await _repo.GetByArtistaIdAsync(ArtistaId);
            if (cita == null) return null;

            return MapToDto(cita);
        }

        public async Task<CitasDto> GetByClienteIdAsync(int ClienteId)
        {
            var cita = await _repo.GetByClienteIdAsync(ClienteId);
            if (cita == null) return null;

            return MapToDto(cita);
        }

        public async Task<CitasDto> GetByEstadoAsync(string Estado)
        {
            var cita = await _repo.GetByEstadoAsync(Estado);
            if (cita == null) return null;

            return MapToDto(cita);
        }

        public  async Task<CitasDto> GetByFechaCitaAsync(DateTime FechaCita)
        {
            var cita = await _repo.GetByFechaCitaAsync(FechaCita);
            if (cita == null) return null;

            return MapToDto(cita);
        }

        public async Task<CitasDto> GetByIdAsync(int id)
        {
            var cita = await _repo.GetByIdAsync(id);
            if (cita == null) return null;

            return MapToDto(cita);
        }

        public async Task<CitasDto> GetByTatuajeIdAsync(int TatuajeId)
        {
            var cita = await _repo.GetByTatuajeIdAsync(TatuajeId);
            if (cita == null) return null;

            return MapToDto(cita);
        }

        public async Task<bool> UpdateAsync(int id, UpdateCitaDto dto)
        {
            var cita = await _repo.GetByIdAsync(id);
            if(cita== null) return false;

            cita.ArtistaId = dto.ArtistaId;
            cita.ClienteId = dto.ClienteId;
            cita.TatuajeId = dto.TatuajeId;
            cita.AnticipoPagado = dto.AnticipoPagado;
            cita.FechaCita = dto.FechaCita;
            cita.Duracion = dto.Duracion;
            cita.Estado = dto.Estado;
            cita.Notas = dto.Notas;
            cita.PrecioFinal = dto.PrecioFinal;

            await _repo.UpdateAsync(cita);
            await _repo.SaveChangesAsync();

            return true;

        }

        private CitasDto MapToDto(Citas cita)
        {
            return new CitasDto
            {
                Id = cita.Id,
                ArtistaId = cita.ArtistaId,
                ClienteId = cita.ClienteId,
                TatuajeId = cita.TatuajeId,
                FechaCita = cita.FechaCita,
                Duracion = cita.Duracion,
                Estado = cita.Estado,
                PrecioFinal = cita.PrecioFinal,
                AnticipoPagado = cita.AnticipoPagado,
                Notas = cita.Notas
            };
        }
    }
}
