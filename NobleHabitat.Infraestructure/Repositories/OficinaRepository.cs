using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class OficinaRepository: Repository<Oficina>, IOficinaRepository
    {
        public OficinaRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<Oficina> GetByIdAsync(Guid id)
        {
            return await _dbContext.oficinas
                .Include(o => o.Id)
                .FirstOrDefaultAsync(o => o.Id == id) 
                ?? throw new KeyNotFoundException($"Oficina with id {id} not found.");
        }
        public async Task<IEnumerable<Oficina>> GetAllWithUsuariosAsync()
        {
            return await _dbContext.oficinas
                .Include(o => o.Agentes)
                .ToListAsync();
        }
    }
}
