using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaService _zonaService;
        public ZonaController(IZonaService zonaService)
        {
            _zonaService = zonaService ?? throw new ArgumentNullException(nameof(zonaService));
        }

        // Metodo para traer todas las zonas
        [HttpGet("zona")]
        public async Task<ActionResult<IEnumerable<ZonaDto>>> GetZonas()
        {
            try
            {
                var zonas = await _zonaService.GetZonasAsync();
                return Ok(zonas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer una zona por ID
        [HttpGet("zona/{id}")]
        public async Task<ActionResult<ZonaDto>> GetZona(Guid id)
        {
            try
            {
                var zona = await _zonaService.GetZonaByIdAsync(id);
                if (zona != null)
                {
                    return Ok(zona);
                }
                else
                {
                    return NotFound($"Zona with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear una zona
        [HttpPost("zona")]
        public async Task<ActionResult<ZonaDto>> CreateZona([FromBody] ZonaDto zonaDto)
        {
            try
            {
                if (zonaDto != null)
                {
                    var createdZona = await _zonaService.CreateZonaAsync(zonaDto);
                    return CreatedAtAction(nameof(GetZona), new { id = createdZona.Id }, createdZona);
                }
                else
                {
                    return BadRequest("Zona data is null.");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar una zona
        [HttpPut("zona/{Id}")]
        public async Task<ActionResult<ZonaDto>> UpdateZona(Guid Id, [FromBody] ZonaDto zonaDto)
        {
            try
            {
                if (zonaDto == null)
                {
                    return BadRequest("Zona data is null.");
                }

                if (Id != zonaDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedZona = await _zonaService.UpdateZonaAsync(zonaDto);
                return Ok(updatedZona);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar una zona
        [HttpDelete("zona/{id}")]
        public async Task<IActionResult> DeleteZona(Guid id)
        {
            try
            {
                await _zonaService.DeleteZonaAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
