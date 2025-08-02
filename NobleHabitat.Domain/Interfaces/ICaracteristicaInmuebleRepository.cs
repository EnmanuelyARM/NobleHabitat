using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Domain.Interfaces
{
    public interface ICaracteristicaInmuebleRepository : IRepository<CaracteristicaInmueble>
    {
        Task<IEnumerable<CaracteristicaInmueble>> GetByInmuebleIdAsync(Guid inmuebleId);
        
    }

}
