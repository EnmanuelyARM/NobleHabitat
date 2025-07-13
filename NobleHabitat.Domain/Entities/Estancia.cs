namespace NobleHabitat.Domain.Entities
{
    public class Estancia
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; } = default!;

        public string Tipo { get; set; } = default!; // Ej. Habitación, Baño, Cocina...
        public string? Caracteristicas { get; set; }
    }
}
