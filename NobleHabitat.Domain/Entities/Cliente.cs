namespace NobleHabitat.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = default!;

        public string Telefono { get; set; } = default!;
        public ICollection<Visita> Visitas { get; set; } = new List<Visita>();
    }

}
