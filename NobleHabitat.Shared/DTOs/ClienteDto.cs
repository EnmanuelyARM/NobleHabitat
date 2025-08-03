using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Telefono { get; set; } = default!;
        public Guid UsuarioId { get; set; }
    }
}
