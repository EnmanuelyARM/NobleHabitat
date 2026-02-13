using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class EstanciaRepository: Repository<Estancia>, IEstanciaRepository
    {
        public EstanciaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Estancia>> GetAllWithInmueblesAsync()
        {
            return await _dbContext.Estancias
                .Include(e => e.Inmueble)
                .ToListAsync();
        }
        public override async Task<Estancia> GetByIdAsync(Guid id)
        {
            return await _dbContext.Estancias
                .Include(e => e.Inmueble)
                .FirstOrDefaultAsync(e => e.Id == id) 
                ?? throw new KeyNotFoundException($"Estancia with id {id} not found.");
        }
        public async Task<IEnumerable<Estancia>> GetByInmuebleIdAsync(Guid inmuebleId)
        {
            return await _dbContext.Estancias
                .Where(e => e.InmuebleId == inmuebleId)
                .ToListAsync();
        }
    }
}
