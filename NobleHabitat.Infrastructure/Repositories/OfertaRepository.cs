using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class OfertaRepository: Repository<Oferta>, IOfertaRepository
    {
        public OfertaRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Oferta>> GetAllWithInmueblesAsync()
        {
            return await _dbContext.ofertas
                .Include(o => o.Inmueble)
                .ToListAsync();
        }
        public async Task<Oferta> GetByIdAsync(Guid id)
        {
            return await _dbContext.ofertas
                .Include(o => o.Inmueble)
                .FirstOrDefaultAsync(o => o.InmuebleId == id) 
                ?? throw new KeyNotFoundException($"Oferta with id {id} not found.");
        }
        public async Task<IEnumerable<Oferta>> GetByInmuebleIdAsync(Guid inmuebleId)
        {
            return await _dbContext.ofertas
                .Where(o => o.InmuebleId == inmuebleId)
                .ToListAsync();
        }
    }
}
