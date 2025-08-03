using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }

        // Metodo para traer todos los clientes
        [HttpGet("cliente")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteService.GetClientesAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer un cliente por ID
        [HttpGet("cliente/{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(Guid id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                else
                {
                    return NotFound($"Cliente with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear un cliente
        [HttpPost("cliente")]
        public async Task<ActionResult<ClienteDto>> CreateCliente([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto != null)
                {
                    var createdCliente = await _clienteService.CreateClienteAsync(clienteDto);
                    return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.Id }, createdCliente);
                }
                else
                {
                    return BadRequest("Cliente data is null.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar un cliente
        [HttpPut("cliente/{Id}")]
        public async Task<ActionResult<ClienteDto>> UpdateCliente(Guid Id, [FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                {
                    return BadRequest("Cliente data is null.");
                }

                if (Id != clienteDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedCliente = await _clienteService.UpdateClienteAsync(clienteDto);
                if (updatedCliente != null)
                {
                    return Ok(updatedCliente);
                }
                else
                {
                    return NotFound($"Cliente with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar un cliente
        [HttpDelete("cliente/{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            try
            {
                await _clienteService.DeleteClienteAsync(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
