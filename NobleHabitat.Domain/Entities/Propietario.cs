namespace NobleHabitat.Domain.Entities
{
    public class Propietario
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = default!;


        public ICollection<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
    }
}
