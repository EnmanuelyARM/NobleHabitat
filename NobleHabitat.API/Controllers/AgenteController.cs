using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenteController : ControllerBase
    {
        private readonly IAgenteService _agenteService;
        public AgenteController(IAgenteService agenteService)
        {
            _agenteService = agenteService ?? throw new ArgumentNullException(nameof(agenteService));
        }

        // Metodo para traer todos los agentes
        [HttpGet("agente")]
        public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAgentes()
        {
            try
            {
                var agentes = await _agenteService.GetAgentsAsync();
                return Ok(agentes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para traer un agente
        [HttpGet("agente/{usuarioId}")]
        public async Task<ActionResult<AgenteDto>> GetAgente(Guid usuarioId)
        {
            try
            {
                var agente = await _agenteService.GetAgentByIdAsync(usuarioId);
                if (agente != null)
                {
                    return Ok(agente);                    
                }
                else
                {
                    return NotFound($"Agent with Usuario ID {usuarioId} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear un agente
        [HttpPost("agente")]
        public async Task<ActionResult<AgenteDto>> CreateAgente([FromBody] AgenteDto agenteDto)
        {            
            try
            {
                if (agenteDto != null)
                {
                    var createdAgent = await _agenteService.CreateAgentAsync(agenteDto);
                    return CreatedAtAction(nameof(GetAgente), new { usuarioId = createdAgent.UsuarioId }, createdAgent);                    
                }
                else
                {
                    return BadRequest("Agent data is null.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar un agente
        [HttpPut("agente/{Id}")]
        public async Task<ActionResult<AgenteDto>> UpdateAgente(Guid Id,[FromBody] AgenteDto agenteDto)
        {
            try
            {
                if (agenteDto == null)
                {
                    return BadRequest("Agent data is null.");
                }

                if (Id != agenteDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedAgent = await _agenteService.UpdateAgentAsync(agenteDto);
                if (updatedAgent != null)
                {
                    return Ok(updatedAgent);
                }
                else
                {
                    return NotFound($"Agent with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar un agente
        [HttpDelete("agente/{usuarioId}")]
        public async Task<IActionResult> DeleteAgentAsync(Guid usuarioId)
        {
            try
            {
                await _agenteService.DeleteAgentAsync(usuarioId);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
