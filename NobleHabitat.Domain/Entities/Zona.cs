namespace NobleHabitat.Domain.Entities
{
    public class Zona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;

        public ICollection<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
    }
}
