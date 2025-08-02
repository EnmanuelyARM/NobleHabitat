using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IInmuebleRepository : IRepository<Inmueble>
    {
        Task<IEnumerable<Inmueble>> GetByZonaAsync(Guid zonaId);
        Task<IEnumerable<Inmueble>> GetByTipoAsync(string tipo);
       
    }

}
