using GestionCitasAPI.Application.DTOs.Artistas;
using GestionCitasAPI.Application.DTOs.Citas;
using GestionCitasAPI.Application.Interfaces.Citas;
using GestionCitasAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitasService _service;

        public CitasController(ICitasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citas = await _service.GetAllAsync();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cita = await _service.GetByIdAsync(id);

            if (cita == null) return NotFound();

            return Ok(cita);
        }

        [HttpGet("ArtistaId/{ArtistaId}")]
        public async Task<IActionResult> GetByIdArtista(int ArtistaId)
        {
            var cita = await _service.GetByArtistaIdAsync(ArtistaId);

            if (cita == null) return NotFound();

            return Ok(cita);
        }

        [HttpGet("TatuajeId/{TatuajeId}")]
        public async Task<IActionResult> GetByTatuajeId(int TatuajeId)
        {
            var cita = await _service.GetByTatuajeIdAsync(TatuajeId);

            if (cita == null) return NotFound();

            return Ok(cita);
        }

        [HttpGet("ClienteId/{ClienteId}")]
        public async Task<IActionResult> GetByClienteId(int ClienteId)
        {
            var cita = await _service.GetByClienteIdAsync(ClienteId);

            if (cita == null) return NotFound();

            return Ok(cita);
        }

        [HttpGet("FechaCita/{FechaCita}")]
        public async Task<IActionResult> GetByFechaCita(DateTime FechaCita)
        {
            var cita = await _service.GetByFechaCitaAsync(FechaCita);

            if (cita == null) return NotFound();

            return Ok(cita);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCitaDto dto)
        {
            var cita = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cita.Id }, cita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCitaDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
