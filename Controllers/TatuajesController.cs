using GestionCitasAPI.Application.DTOs.Clientes;
using GestionCitasAPI.Application.DTOs.Tatuajes;
using GestionCitasAPI.Application.Interfaces.Tatuajes;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TatuajesController : ControllerBase
    {
        private readonly ITatuajesService _service;

        public TatuajesController(ITatuajesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tatuajes = await _service.GetAllAsync();
            return Ok(tatuajes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tatuaje = await _service.GetByIdAsync(id);

            if (tatuaje == null)
                return NotFound();

            return Ok(tatuaje);
        }

        [HttpGet("FechaCreacion/{FechaCreacion}")]
        public async Task<IActionResult> GetByFechaCreacion(DateTime FechaCreacion)
        {
            var tatuaje = await _service.GetByFechaCreacionAsync(FechaCreacion);

            if (tatuaje == null)
                return NotFound();

            return Ok(tatuaje);
        }

        [HttpGet("CategoriaId/{CategoriaId}")]
        public async Task<IActionResult> GetByCategoriaId(int CategoriaId)
        {
            var tatuaje = await _service.GetByCategoriaIdAsync(CategoriaId);

            if (tatuaje == null)
                return NotFound();

            return Ok(tatuaje);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTatuajeDto dto)
        {
            var tatuaje = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = tatuaje.Id }, tatuaje);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTatuajeDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

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
