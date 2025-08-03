using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class ZonaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
    }
}
