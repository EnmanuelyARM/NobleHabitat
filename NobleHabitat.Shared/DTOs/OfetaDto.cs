using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class OfertaDto
    {
        public Guid Id { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid InmuebleId { get; set; }
        public Guid AgenteId { get; set; }
    }
}
