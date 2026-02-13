using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class OficinaRepository: Repository<Oficina>, IOficinaRepository
    {
        public OficinaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Oficina> GetByIdAsync(Guid id)
        {
            return await _dbContext.Oficinas
                .Include(o => o.Id)
                .FirstOrDefaultAsync(o => o.Id == id) 
                ?? throw new KeyNotFoundException($"Oficina with id {id} not found.");
        }
        public async Task<IEnumerable<Oficina>> GetAllWithUsuariosAsync()
        {
            return await _dbContext.Oficinas
                .Include(o => o.Agentes)
                .ToListAsync();
        }
    }
}
