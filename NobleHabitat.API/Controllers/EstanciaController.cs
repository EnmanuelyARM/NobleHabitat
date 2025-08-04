using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstanciaController : ControllerBase
    {
        private readonly IEstanciaService _estanciaService;
        public EstanciaController(IEstanciaService estanciaService)
        {
            _estanciaService = estanciaService ?? throw new ArgumentNullException(nameof(estanciaService));
        }

        // Metodo para traer todas las estancias
        [HttpGet("estancia")]
        public async Task<ActionResult<IEnumerable<EstanciaDto>>> GetEstancias()
        {
            try
            {
                var estancias = await _estanciaService.GetEstanciasAsync();
                return Ok(estancias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear una estancia
        [HttpPost("estancia")]
        public async Task<ActionResult<EstanciaDto>> CreateEstancia([FromBody] EstanciaDto estanciaDto)
        {
            try
            {
                if (estanciaDto == null)
                {
                    return BadRequest("Estancia data is null.");
                }
                var createdEstancia = await _estanciaService.CreateEstanciaAsync(estanciaDto);
                return CreatedAtAction(nameof(GetEstancias), new { id = createdEstancia.Id }, createdEstancia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar una estancia
        [HttpPut("estancia/{Id}")]
        public async Task<ActionResult<EstanciaDto>> UpdateEstancia(Guid Id, [FromBody] EstanciaDto estanciaDto)
        {
            try
            {
                if (estanciaDto == null)
                {
                    return BadRequest("Estancia data is null.");
                }

                if (Id != estanciaDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedEstancia = await _estanciaService.UpdateEstanciaAsync(estanciaDto);
                if (updatedEstancia != null)
                {
                    return Ok(updatedEstancia);
                }
                else
                {
                    return NotFound($"Estancia with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpDelete("estancia/{id}")]
        public async Task<IActionResult> DeleteEstancia(Guid id)
        {
            try
            {
                await _estanciaService.DeleteEstanciaAsync(id);
                return NoContent(); // 204 No Content es una convención común para delete
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Estancia with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
