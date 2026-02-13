using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class PropietarioRepository : Repository<Propietario>, IPropietarioRepository
    {
        public PropietarioRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Propietario> GetByIdAsync(Guid id)
        {
            return await _dbContext.Propietarios
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new KeyNotFoundException($"Propietario with id {id} not found.");
        }
        public async Task<IEnumerable<Propietario>> GetAllWithUsuariosAsync()
        {
            return await _dbContext.Propietarios
                .Include(p => p.Usuario)
                .ToListAsync();
        }
    }
}
