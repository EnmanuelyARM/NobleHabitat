using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class ZonaRepository: Repository<Zona>, IZonaRepository
    {
        public ZonaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Zona> GetByIdAsync(Guid id)
        {
            return await _dbContext.Zonas
                .Include(z => z.Oficina)
                .FirstOrDefaultAsync(z => z.Id == id) 
                ?? throw new KeyNotFoundException($"Zona with id {id} not found.");
        }
        public async Task<IEnumerable<Zona>> GetAllWithOficinasAsync()
        {
            return await _dbContext.Zonas
                .Include(z => z.Oficina)
                .ToListAsync();
        }
    }
}
