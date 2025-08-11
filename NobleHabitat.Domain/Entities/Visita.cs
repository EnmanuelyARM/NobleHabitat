namespace NobleHabitat.Domain.Entities
{
    public class Visita
    {
        public Guid Id { get; set; }

        public Guid InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; } = default!;

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = default!;

        public DateTime FechaHora { get; set; }
        public string? Comentario { get; set; }
        public Propietario Propietario { get; set; } = default!;
        public Oficina Oficina { get; set; } = default!;
        public Agente Agente { get; set; } = default!;
        public Guid AgenteId { get; set; }

    }
}
