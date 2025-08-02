using NobleHabitat.Domain.Entities;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        
    }

}
