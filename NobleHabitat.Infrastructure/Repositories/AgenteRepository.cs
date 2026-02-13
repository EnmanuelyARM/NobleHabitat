using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class AgenteRepository: Repository<Agente>, IAgenteRepository
    {
        public AgenteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Agente?> GetByUsuarioIdAsync(Guid usuarioId)
        {
            return await _dbContext.Agentes
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.UsuarioId == usuarioId);
        }
        
        public async Task<IEnumerable<Agente>> GetAllWithUsuariosAsync()
        {
            return await _dbContext.Agentes
                .Include(a => a.Usuario)
                .ToListAsync();
        }

        public override async Task<Agente> GetByIdAsync(Guid id)
        {
            return await _dbContext.Agentes
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.Id == id) 
                ?? throw new KeyNotFoundException($"Agente with id {id} not found.");
        }
    }
}
