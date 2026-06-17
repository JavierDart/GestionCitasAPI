using GestionCitasAPI.Application.DTOs.CatTatuajes;
using GestionCitasAPI.Application.Interfaces.CatTatuajes;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatTatuajesController :ControllerBase
    {
        private readonly ICatTatuajesService _service;

        public CatTatuajesController(ICatTatuajesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _service.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categorias = await _service.GetByIdAsync(id);

            if (categorias == null) return NotFound();

            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCatTatuajeDto dto)
        {
            var categorias = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = categorias.Id }, categorias);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCatTatuajeDto dto)
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
