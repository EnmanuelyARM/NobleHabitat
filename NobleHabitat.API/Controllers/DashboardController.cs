using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDBContext _db;

        public DashboardController(AppDBContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<DashboardDto>> Get()
        {
            try
            {
                var dto = new DashboardDto
                {
                    TotalUsuarios = await _db.usuarios.CountAsync(),
                    TotalAgentes = await _db.agentes.CountAsync(),
                    TotalClientes = await _db.clientes.CountAsync(),
                    TotalPropietarios = await _db.propietarios.CountAsync(),
                    TotalInmuebles = await _db.inmuebles.CountAsync(),
                    TotalOficinas = await _db.oficinas.CountAsync(),
                    TotalVisitas = await _db.visitas.CountAsync(),
                    OfertasEnVenta = await _db.ofertas.CountAsync(o => o.EnVenta),
                    OfertasEnAlquiler = await _db.ofertas.CountAsync(o => o.EnAlquiler)
                };

                // Inmuebles por zona (nombre, count)
                var inmueblesPorZona = await _db.inmuebles
                    .Include(i => i.Zona)
                    .Where(i => i.ZonaId != null)
                    .GroupBy(i => i.Zona!.Nombre)
                    .Select(g => new { Zona = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToListAsync();

                dto.InmueblesPorZona = inmueblesPorZona
                    .Select(x => new KeyValuePair<string, int>(x.Zona ?? "Sin Zona", x.Count))
                    .ToList();

                // Últimas 10 visitas - CORREGIDO: Convertir Guid a string
                var ultimas = await _db.visitas
                    .Include(v => v.Inmueble)
                    .Include(v => v.Agente).ThenInclude(a => a.Usuario)
                    .Include(v => v.Cliente).ThenInclude(c => c.Usuario)
                    .OrderByDescending(v => v.FechaHora)
                    .Take(10)
                    .Select(v => new UltimaVisitaDto
                    {
                        Id = v.Id.ToString(), // Convertir Guid a string
                        FechaHora = v.FechaHora,
                        InmuebleDireccion = v.Inmueble.Direccion ?? "",
                        AgenteNombre = v.Agente != null && v.Agente.Usuario != null ? v.Agente.Usuario.Nombre ?? "" : "",
                        ClienteTelefono = v.Cliente != null ? v.Cliente.Telefono ?? "" : ""
                    }).ToListAsync();

                dto.UltimasVisitas = ultimas;

                // Visitas últimos 7 días
                var desde = DateTime.UtcNow.Date.AddDays(-6);
                var visitas7 = await _db.visitas
                    .Where(v => v.FechaHora >= desde)
                    .GroupBy(v => v.FechaHora.Date)
                    .Select(g => new { Day = g.Key, Count = g.Count() })
                    .ToListAsync();

                // Fill days with 0 when missing and format labels
                var chartList = new List<KeyValuePair<string, int>>();
                for (int i = 0; i < 7; i++)
                {
                    var day = desde.AddDays(i);
                    var found = visitas7.FirstOrDefault(x => x.Day == day);
                    chartList.Add(new KeyValuePair<string, int>(day.ToString("yyyy-MM-dd"), found?.Count ?? 0));
                }

                dto.VisitasUltimos7Dias = chartList;

                return Ok(dto);
            }
            catch (Exception ex)
            {
                // Log del error para debugging
                Console.WriteLine($"Error in DashboardController: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");

                return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
            }
        }
    }
}