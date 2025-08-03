using NobleHabitat.Domain.Entities;


namespace NobleHabitat.Shared.DTOs
{
    public class AgenteDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid OficinaId { get; set; }
    }
}
