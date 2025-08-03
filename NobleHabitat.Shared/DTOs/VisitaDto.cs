using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class VisitaDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; } = default!;
        public Guid ClienteId { get; set; }
        public Guid InmuebleId { get; set; }
    }
}
