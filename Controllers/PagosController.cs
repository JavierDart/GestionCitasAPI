using GestionCitasAPI.Application.DTOs.Pagos;
using GestionCitasAPI.Application.Interfaces.Pagos;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagosService _service;

        public PagosController(IPagosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagos = await _service.GetAllAsync();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _service.GetByIdAsync(id);

            if (pago == null) return NotFound();

            return Ok(pago);
        }

        [HttpGet("CitaId/{CitaId}")]
        public async Task<IActionResult> GetByCitaId(int CitaId)
        {
            var pago = await _service.GetByCitaIdAsync(CitaId);

            if (pago == null) return NotFound();

            return Ok(pago);
        }

        [HttpGet("FechaPago/{FechaPago}")]
        public async Task<IActionResult> GetByFechaPago(DateTime FechaPago)
        {
            var pago = await _service.GetByFechaPagoAsync(FechaPago);

            if (pago == null) return NotFound();

            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePagoDto dto)
        {
            var pago = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = pago.Id }, pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePagoDto dto)
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
