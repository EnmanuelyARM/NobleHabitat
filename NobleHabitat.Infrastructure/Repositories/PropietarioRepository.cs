using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class PropietarioRepository : Repository<Propietario>, IPropietarioRepository
    {
        public PropietarioRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<Propietario> GetByIdAsync(Guid id)
        {
            return await _dbContext.propietarios
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new KeyNotFoundException($"Propietario with id {id} not found.");
        }
        public async Task<IEnumerable<Propietario>> GetAllWithUsuariosAsync()
        {
            return await _dbContext.propietarios
                .Include(p => p.Usuario)
                .ToListAsync();
        }
    }
}
