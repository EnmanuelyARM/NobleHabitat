using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitaController : ControllerBase
    {
        private readonly IVisitaService _visitaService;
        public VisitaController(IVisitaService visitaService)
        {
            _visitaService = visitaService ?? throw new ArgumentNullException(nameof(visitaService));
        }

        // Metodo para traer todas las visitas
        [HttpGet("visita")]
        public async Task<ActionResult<IEnumerable<VisitaDto>>> GetVisitas()
        {
            try
            {
                var visitas = await _visitaService.GetVisitasAsync();
                return Ok(visitas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer una visita por ID
        [HttpGet("visita/{id}")]
        public async Task<ActionResult<VisitaDto>> GetVisita(Guid id)
        {
            try
            {
                var visita = await _visitaService.GetVisitaByIdAsync(id);
                if (visita != null)
                {
                    return Ok(visita);
                }
                else
                {
                    return NotFound($"Visita with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // Metodo para crear una visita
        [HttpPost("visita")]
        public async Task<ActionResult<VisitaDto>> CreateVisita([FromBody] VisitaDto visitaDto)
        {
            try
            {
                if (visitaDto == null)
                {
                    return BadRequest("Visita data is null.");
                }
                var createdVisita = await _visitaService.CreateVisitaAsync(visitaDto);
                return CreatedAtAction(nameof(GetVisita), new { id = createdVisita.Id }, createdVisita);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // Metodo para actualizar una visita
        [HttpPut("visita/{Id}")]
        public async Task<ActionResult<VisitaDto>> UpdateVisita(Guid Id, [FromBody] VisitaDto visitaDto)
        {
            try
            {
                if (visitaDto == null)
                {
                    return BadRequest("Visita data is null");
                }

                if (Id != visitaDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body");
                }

                var updatedVisita = await _visitaService.UpdateVisitaAsync(visitaDto);
                return Ok(updatedVisita);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar una visita
        [HttpDelete("visita/{id}")]
        public async Task<IActionResult> DeleteVisita(Guid id)
        {
            try
            {
                var visita = await _visitaService.GetVisitaByIdAsync(id);
                if (visita != null)
                {
                    await _visitaService.DeleteVisitaAsync(id);
                    return NoContent();
                }
                else
                {
                    return NotFound($"Visita with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
