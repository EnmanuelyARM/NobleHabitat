namespace NobleHabitat.Domain.Entities
{
    public class Oferta
    {
        InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; } = default!;

        public bool EnVenta { get; set; }
        public bool EnAlquiler { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal? PrecioAlquiler { get; set; }
    }
}
