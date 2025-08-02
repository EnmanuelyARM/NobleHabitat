using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IVisitaRepository : IRepository<Visita>
    {
        Task<IEnumerable<Visita>> GetByInmuebleIdAsync(Guid inmuebleId);
        Task<IEnumerable<Visita>> GetByClienteIdAsync(Guid clienteId);
       
    }

}
