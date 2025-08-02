using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IOfertaRepository : IRepository<Oferta>
    {
        Task<Oferta?> GetByInmuebleIdAsync(Guid inmuebleId);
        
    }

}
