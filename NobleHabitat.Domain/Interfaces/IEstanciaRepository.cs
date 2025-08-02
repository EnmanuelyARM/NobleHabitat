using NobleHabitat.Domain.Entities;


namespace NobleHabitat.Domain.Interfaces
{
    public interface IEstanciaRepository : IRepository<Estancia>
    {
        Task<IEnumerable<Estancia>> GetByInmuebleIdAsync(Guid inmuebleId);
       
    }

}
