namespace NobleHabitat.Domain.Entities
{
    public class Agente
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = default!;

        public Guid OficinaId { get; set; }
        public Oficina Oficina { get; set; } = default!;

        public ICollection<Inmueble> InmueblesAsignados { get; set; } = new List<Inmueble>();
    }

}
