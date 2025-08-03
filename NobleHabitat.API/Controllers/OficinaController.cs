using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OficinaController : ControllerBase
    {
        private readonly IOficinaService _oficinaService;
        public OficinaController(IOficinaService oficinaService)
        {
            _oficinaService = oficinaService ?? throw new ArgumentNullException(nameof(oficinaService));
        }

        // Metodo para traer todas las oficinas
        [HttpGet("oficina")]
        public async Task<ActionResult<IEnumerable<OficinaDto>>> GetOficinas()
        {
            try
            {
                var oficinas = await _oficinaService.GetOficinasAsync();
                return Ok(oficinas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear una oficina
        [HttpPost("oficina")]
        public async Task<ActionResult<OficinaDto>> CreateOficina([FromBody] OficinaDto oficinaDto)
        {
            try
            {
                if (oficinaDto == null)
                {
                    return BadRequest("Oficina data is null.");
                }
                var createdOficina = await _oficinaService.CreateOficinaAsync(oficinaDto);
                return CreatedAtAction(nameof(GetOficinas), new { id = createdOficina.Id }, createdOficina);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar una oficina
        [HttpPut("oficina/{Id}")]
        public async Task<ActionResult<OficinaDto>> UpdateOficina(Guid Id, [FromBody] OficinaDto oficinaDto)
        {
            try
            {
                if (oficinaDto == null)
                {
                    return BadRequest("Oficina data is null.");
                }

                if (Id != oficinaDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedOficina = await _oficinaService.UpdateOficinaAsync(oficinaDto);
                if (updatedOficina != null)
                {
                    return Ok(updatedOficina);
                }
                else
                {
                    return NotFound($"Oficina with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar una oficina
        [HttpDelete("oficina/{id}")]
        public async Task<IActionResult> DeleteOficinaAsync(Guid id)
        {
            try
            {
                await _oficinaService.DeleteOficinaAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Oficina with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
