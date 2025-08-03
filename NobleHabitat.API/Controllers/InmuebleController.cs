using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InmuebleController : ControllerBase
    {
        private readonly IInmuebleService _inmuebleService;
        public InmuebleController(IInmuebleService inmuebleService)
        {
            _inmuebleService = inmuebleService ?? throw new ArgumentNullException(nameof(inmuebleService));
        }

        // Metodo para traer todos los inmuebles
        [HttpGet("inmueble")]
        public async Task<ActionResult<IEnumerable<InmuebleDto>>> GetInmuebles()
        {
            try
            {
                var inmuebles = await _inmuebleService.GetInmueblesAsync();
                return Ok(inmuebles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer un inmueble por ID
        [HttpGet("inmueble/{id}")]
        public async Task<ActionResult<InmuebleDto>> GetInmueble(Guid id)
        {
            try
            {
                var inmueble = await _inmuebleService.GetInmuebleByIdAsync(id);
                if (inmueble != null)
                {
                    return Ok(inmueble);
                }
                else
                {
                    return NotFound($"Inmueble with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear un inmueble
        [HttpPost("inmueble")]
        public async Task<ActionResult<InmuebleDto>> CreateInmueble([FromBody] InmuebleDto inmuebleDto)
        {
            try
            {
                if (inmuebleDto == null)
                {
                    return BadRequest("Inmueble data is null.");
                }
                var createdInmueble = await _inmuebleService.CreateInmuebleAsync(inmuebleDto);
                return CreatedAtAction(nameof(GetInmuebles), new { id = createdInmueble.Id }, createdInmueble);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // Metodo para actualizar un inmueble
        [HttpPut("inmueble/{Id}")]
        public async Task<ActionResult<InmuebleDto>> UpdateInmueble(Guid Id, [FromBody] InmuebleDto inmuebleDto)
        {
            try
            {
                if (inmuebleDto == null)
                {
                    return BadRequest("Inmueble data is null.");
                }

                if (Id != inmuebleDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedInmueble = await _inmuebleService.UpdateInmuebleAsync(inmuebleDto);
                if (updatedInmueble != null)
                {
                    return Ok(updatedInmueble);
                }
                else
                {
                    return NotFound($"Inmueble with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar un inmueble
        [HttpDelete("inmueble/{id}")]
        public async Task<IActionResult> DeleteInmueble(Guid id)
        {
            try
            {
                await _inmuebleService.DeleteInmuebleAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Inmueble with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
