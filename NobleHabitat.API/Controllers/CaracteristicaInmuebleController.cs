using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaracteristicaInmuebleController : ControllerBase
    {        
        private readonly ICaracteristicaInmuebleService _caracteristicaInmuebleService;
        public CaracteristicaInmuebleController(ICaracteristicaInmuebleService caracteristicaInmuebleService)
        {
            _caracteristicaInmuebleService = caracteristicaInmuebleService ?? throw new ArgumentNullException(nameof(caracteristicaInmuebleService));
        }

        // Metodo para traer todas las caracteristicas de inmueble
        [HttpGet("caracteristica-inmueble")]
        public async Task<ActionResult<IEnumerable<CaracteristicaInmuebleDto>>> GetCaracteristicasInmueble()
        {
            try
            {
                var caracteristicas = await _caracteristicaInmuebleService.GetCaracteristicasAsync();
                return Ok(caracteristicas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer una caracteristica de inmueble por ID
        [HttpGet("caracteristica-inmueble/{id}")]
        public async Task<ActionResult<CaracteristicaInmuebleDto>> GetCaracteristicaInmueble(int id)
        {
            try
            {
                var caracteristica = await _caracteristicaInmuebleService.GetCaracteristicaByIdAsync(id);
                if (caracteristica != null)
                {
                    return Ok(caracteristica);
                }
                else
                {
                    return NotFound($"Caracteristica with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear una caracteristica de inmueble
        [HttpPost("caracteristica-inmueble")]
        public async Task<ActionResult<CaracteristicaInmuebleDto>> CreateCaracteristicaInmueble([FromBody] CaracteristicaInmuebleDto caracteristicaDto)
        {
            try
            {
                if (caracteristicaDto == null)
                {
                    return BadRequest("Caracteristica cannot be null.");
                }
                var createdCaracteristica = await _caracteristicaInmuebleService.CreateCaracteristicaAsync(caracteristicaDto);
                return CreatedAtAction(nameof(GetCaracteristicaInmueble), new { id = createdCaracteristica.Id }, createdCaracteristica);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // Metodo para actualizar una caracteristica de inmueble
        [HttpPut("caracteristica-inmueble/{Id}")]
        public async Task<ActionResult<CaracteristicaInmuebleDto>> UpdateCaracteristicaInmueble(Guid Id, [FromBody] CaracteristicaInmuebleDto caracteristicaDto)
        {
            try
            {
                if (caracteristicaDto == null)
                {
                    return BadRequest("Caracteristica cannot be null.");
                }

                if (Id != caracteristicaDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedCaracteristica = await _caracteristicaInmuebleService.UpdateCaracteristicaAsync(caracteristicaDto);
                if (updatedCaracteristica != null)
                {
                    return Ok(updatedCaracteristica);
                }
                else
                {
                    return NotFound($"Caracteristica with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar una caracteristica de inmueble
        [HttpDelete("caracteristica-inmueble/{id}")]
        public async Task<IActionResult> DeleteCaracteristicaInmueble(int id)
        {
            try
            {
                await _caracteristicaInmuebleService.DeleteCaracteristicaAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Caracteristica with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
