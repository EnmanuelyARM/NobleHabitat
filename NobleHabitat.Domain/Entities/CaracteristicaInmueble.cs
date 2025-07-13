namespace NobleHabitat.Domain.Entities
{
    public class CaracteristicaInmueble
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; } = default!;

        public string Descripcion { get; set; } = default!; // Ej. Parquet, Gas ciudad, Diáfano...
    }
}
