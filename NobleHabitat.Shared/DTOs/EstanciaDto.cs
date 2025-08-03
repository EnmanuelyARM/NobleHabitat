using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class EstanciaDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = default!;
        public double Superficie { get; set; }
        public Guid InmuebleId { get; set; }
    }
}
