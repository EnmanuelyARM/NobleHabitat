using Microsoft.AspNetCore.Mvc;
using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaService _ofertaService;
        public OfertaController(IOfertaService ofertaService)
        {
            _ofertaService = ofertaService ?? throw new ArgumentNullException(nameof(ofertaService));
        }

        // Metodo para traer todas las ofertas
        [HttpGet("oferta")]
        public async Task<ActionResult<IEnumerable<OfertaDto>>> GetOfertas()
        {
            try
            {
                var ofertas = await _ofertaService.GetOfertasAsync();
                return Ok(ofertas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para crear una oferta
        [HttpPost("oferta")]
        public async Task<ActionResult<OfertaDto>> CreateOferta([FromBody] OfertaDto ofertaDto)
        {
            try
            {
                if (ofertaDto == null)
                {
                    return BadRequest("Oferta data is null.");
                }
                var createdOferta = await _ofertaService.CreateOfertaAsync(ofertaDto);
                return CreatedAtAction(nameof(GetOfertas), new { id = createdOferta.Id }, createdOferta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Metodo para actualizar una oferta
        [HttpPut("oferta/{Id}")]
        public async Task<ActionResult<OfertaDto>> UpdateOferta(Guid Id, [FromBody] OfertaDto ofertaDto)
        {
            try
            {
                if (ofertaDto == null)
                {
                    return BadRequest("Oferta data is null.");
                }

                if (Id != ofertaDto.Id)
                {
                    return BadRequest("ID in URL does not match ID in body.");
                }

                var updatedOferta = await _ofertaService.UpdateOfertaAsync(ofertaDto);
                if (updatedOferta != null)
                {
                    return Ok(updatedOferta);
                }
                else
                {
                    return NotFound($"Oferta with ID {Id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // Metodo para eliminar una oferta
        [HttpDelete("oferta/{Id}")]
        public async Task<IActionResult> DeleteOferta(Guid Id)
        {
            try
            {
                await _ofertaService.DeleteOfertaAsync(Id);
                return NoContent(); // 204
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Oferta with ID {Id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
