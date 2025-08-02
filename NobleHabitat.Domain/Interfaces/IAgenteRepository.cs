using NobleHabitat.Domain.Entities;


namespace NobleHabitat.Domain.Interfaces
{
    public interface IAgenteRepository : IRepository<Agente>
    {
        Task<Agente?> GetByUsuarioIdAsync(Guid UsuarioId);
    }

}
