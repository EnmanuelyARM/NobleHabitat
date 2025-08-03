using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropietarioController : ControllerBase
    {
        private readonly IPropietarioService _propietarioService;
        public PropietarioController(IPropietarioService propietarioService)
        {
            _propietarioService = propietarioService ?? throw new ArgumentNullException(nameof(propietarioService));
        }

        // Metodo para traer todos los propietarios
        [HttpGet("propietario")]
        public async Task<ActionResult<IEnumerable<PropietarioDto>>> GetPropietarios()
        {
            try
            {
                var propietarios = await _propietarioService.GetPropietariosAsync();
                return Ok(propietarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer un propietario por ID
        [HttpGet("propietario/{id}")]
        public async Task<ActionResult<PropietarioDto>> GetPropietario(Guid id)
        {
            try
            {
                var propietario = await _propietarioService.GetPropietarioByIdAsync(id);
                if (propietario != null)
                {
                    return Ok(propietario);
                }
                else
                {
                    return NotFound($"Propietario with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear un propietario
        [HttpPost("propietario")]
        public async Task<ActionResult<PropietarioDto>> CreatePropietario([FromBody] PropietarioDto propietarioDto)
        {
            try
            {
                if (propietarioDto == null)
                {
                    return BadRequest("Propietario data is null.");
                }
                var createdPropietario = await _propietarioService.CreatePropietarioAsync(propietarioDto);
                return CreatedAtAction(nameof(GetPropietario), new { id = createdPropietario.Id }, createdPropietario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar un propietario
        [HttpPut("propietario/{Id}")]
        public async Task<ActionResult<PropietarioDto>> UpdatePropietario(Guid Id, [FromBody] PropietarioDto propietarioDto)
        {
            try
            {
                if (propietarioDto == null)
                {
                    return BadRequest("Propietario data is null.");
                }

                if (Id != propietarioDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedPropietario = await _propietarioService.UpdatePropietarioAsync(propietarioDto);
                if (updatedPropietario != null)
                {
                    return Ok(updatedPropietario);
                }
                else
                {
                    return NotFound($"Propietario with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // Metodo para eliminar un propietario
        [HttpDelete("propietario/{id}")]
        public async Task<IActionResult> DeletePropietario(Guid id)
        {
            try
            {
                await _propietarioService.DeletePropietarioAsync(id);
                return NoContent(); // 204 No Content

            } catch (KeyNotFoundException)
            {
                return NotFound($"Propietario with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
