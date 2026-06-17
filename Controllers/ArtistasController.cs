using GestionCitasAPI.Application.DTOs.Artistas;
using GestionCitasAPI.Application.Interfaces.Artistas;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistasController: ControllerBase
    {
        private readonly IArtistasService _service;

        public ArtistasController(IArtistasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artistas = await _service.GetAllAsync();
            return Ok(artistas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var artista = await _service.GetByIdAsync(id);

            if(artista == null) return NotFound();

            return Ok(artista);
        }

        [HttpGet("telefono/{telefono}")]
        public async Task<IActionResult> GetByTelefono(string telefono)
        {
            var artista = await _service.GetByTelefonoAsync(telefono);

            if (artista == null) return NotFound();

            return Ok(artista);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArtistaDto dto)
        {
            var artista = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = artista.Id }, artista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateArtistaDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if(!updated) return NotFound();
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
