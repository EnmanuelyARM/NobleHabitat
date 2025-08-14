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

        // Método para traer todos los agentes
        [HttpGet]
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

        // Método para traer un agente por ID de usuario
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<AgenteDto>> GetAgenteByUsuarioId(Guid usuarioId)
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

        // Método para traer un agente por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenteDto>> GetAgente(Guid id)
        {
            try
            {
                var agente = await _agenteService.GetAgentByIdAsync(id);
                if (agente != null)
                {
                    return Ok(agente);                    
                }
                else
                {
                    return NotFound($"Agent with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Método para crear un agente
        [HttpPost]
        public async Task<ActionResult<AgenteDto>> CreateAgente([FromBody] AgenteDto agenteDto)
        {            
            try
            {
                if (agenteDto != null)
                {
                    var createdAgent = await _agenteService.CreateAgentAsync(agenteDto);
                    return CreatedAtAction(nameof(GetAgente), new { id = createdAgent.Id }, createdAgent);                    
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

        // Método para actualizar un agente
        [HttpPut("{id}")]
        public async Task<ActionResult<AgenteDto>> UpdateAgente(Guid id, [FromBody] AgenteDto agenteDto)
        {
            try
            {
                if (agenteDto == null)
                {
                    return BadRequest("Agent data is null.");
                }

                if (id != agenteDto.Id)
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
                    return NotFound($"Agent with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Método para eliminar un agente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgente(Guid id)
        {
            try
            {
                await _agenteService.DeleteAgentAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Método adicional para eliminar por Usuario ID si es necesario
        [HttpDelete("usuario/{usuarioId}")]
        public async Task<IActionResult> DeleteAgenteByUsuarioId(Guid usuarioId)
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