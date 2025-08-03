using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class OficinaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Direccion { get; set; } = default!;
        public string Telefono { get; set; } = default!;
    }
}
