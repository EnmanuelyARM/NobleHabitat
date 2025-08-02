namespace NobleHabitat.Domain.Entities
{
    public class Oficina
    {
        
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Direccion { get; set; } = default!;

        public ICollection<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
        public required object Agentes { get; set; }
    }
}
}
