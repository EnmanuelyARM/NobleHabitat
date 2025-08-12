using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        // Metodo para traer todos los usuarios
        [HttpGet("usuario")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            try
            {
                //logger.loginformation("Entró al método GetUsuario");

                var usuarios = await _usuarioService.GetUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para traer un usuario por ID
        [HttpGet("usuario/{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(Guid id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound($"Usuario with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear un usuario
        [HttpPost("usuario")]
        public async Task<ActionResult<UsuarioDto>> CreateUsuario([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                {
                    return BadRequest("Usuario data is null.");
                }
                var createdUsuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
                return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, createdUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar un usuario
        [HttpPut("usuario/{Id}")]
        public async Task<ActionResult<UsuarioDto>> UpdateUsuario(Guid Id, [FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                {
                    return BadRequest("Usuario data is null.");
                }

                if (Id != usuarioDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedUsuario = await _usuarioService.UpdateUsuarioAsync(usuarioDto);
                return Ok(updatedUsuario);
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


        // Metodo para eliminar un usuario
        [HttpDelete("usuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            try
            {
                await _usuarioService.DeleteUsuarioAsync(id);
                return NoContent(); // 204 No Content
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
