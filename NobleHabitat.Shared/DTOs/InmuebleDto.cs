using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Shared.DTOs
{
    public class InmuebleDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = default!;
        public double Superficie { get; set; }
        public string Direccion { get; set; } = default!;
        public bool PoseeLlaves { get; set; }
        public Guid OficinaId { get; set; }
        public Guid PropietarioId { get; set; }
        public Guid? ZonaId { get; set; }
        public string Titulo { get; set; } = default!;
        public string ImagenUrl { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public decimal Precio { get; set; }
        public string Ubicacion { get; set; } = default!;
    }
}
