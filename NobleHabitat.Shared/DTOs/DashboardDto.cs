namespace NobleHabitat.Shared.DTOs
{
    public class DashboardDto
    {
        public int TotalUsuarios { get; set; }
        public int TotalAgentes { get; set; }
        public int TotalClientes { get; set; }
        public int TotalPropietarios { get; set; }
        public int TotalInmuebles { get; set; }
        public int TotalOficinas { get; set; }
        public int TotalVisitas { get; set; }
        public int OfertasEnVenta { get; set; }
        public int OfertasEnAlquiler { get; set; }

        public List<KeyValuePair<string, int>> InmueblesPorZona { get; set; } = new();
        public List<UltimaVisitaDto> UltimasVisitas { get; set; } = new();
        public List<KeyValuePair<string, int>> VisitasUltimos7Dias { get; set; } = new();
    }

    public class UltimaVisitaDto
    {
        public string Id { get; set; } = string.Empty; // Cambiado a string
        public DateTime FechaHora { get; set; }
        public string InmuebleDireccion { get; set; } = string.Empty;
        public string AgenteNombre { get; set; } = string.Empty;
        public string ClienteTelefono { get; set; } = string.Empty;
    }
}