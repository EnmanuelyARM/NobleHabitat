namespace NobleHabitat.Domain.Entities
{
    public class Inmueble
    {
            public Guid Id { get; set; }
            public string Tipo { get; set; } = default!; // Piso, Villa, Local...
            public double Superficie { get; set; }
            public string Direccion { get; set; } = default!;
            public bool PoseeLlaves { get; set; }

            public Guid OficinaId { get; set; }
            public Oficina Oficina { get; set; } = default!;

            public Guid PropietarioId { get; set; }
            public Propietario Propietario { get; set; } = default!;

            public Guid? ZonaId { get; set; }
            public Zona? Zona { get; set; }

            public Oferta Oferta { get; set; } = default!;
            public ICollection<Estancia> Estancias { get; set; } = new List<Estancia>();
            public ICollection<CaracteristicaInmueble> Caracteristicas { get; set; } = new List<CaracteristicaInmueble>();
            public ICollection<Visita> Visitas { get; set; } = new List<Visita>();

    }
}
