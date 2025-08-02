using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class AgenteRepository: Repository<Agente>, IAgenteRepository
    {
        public AgenteRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<Agente?> GetByUsuarioIdAsync(Guid usuarioId)
        {
            return await _dbContext.agentes
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.UsuarioId == usuarioId);
        }
        
        public async Task<IEnumerable<Agente>> GetAllWithUsuariosAsync()
        {
            return await _dbContext.agentes
                .Include(a => a.Usuario)
                .ToListAsync();
        }

        public async Task<Agente> GetByIdAsync(Guid id)
        {
            return await _dbContext.agentes
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(a => a.Id == id) 
                ?? throw new KeyNotFoundException($"Agente with id {id} not found.");
        }
    }
}
