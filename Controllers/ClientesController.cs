using GestionCitasAPI.Application.DTOs.Clientes;
using GestionCitasAPI.Application.Interfaces.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _service;

        public ClientesController(IClientesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _service.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet("dni/{dni}")]
        public async Task<IActionResult> GetByDNI(string dni)
        {
            var cliente = await _service.GetByDNIAsync(dni);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet("telefono/{telefono}")]
        public async Task<IActionResult> GetByTelefono(string telefono)
        {
            var cliente = await _service.GetByTelefonoAsync(telefono);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteDto dto)
        {
            var cliente = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClienteDto dto)
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