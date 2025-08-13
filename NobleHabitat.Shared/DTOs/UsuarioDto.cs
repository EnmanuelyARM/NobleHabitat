using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool EsAdmin { get; set; } = default!;
    }
}
