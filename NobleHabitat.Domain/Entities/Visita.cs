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
        public object? Propietario { get; set; }
        public object? Oficina { get; set; }
    }
}
