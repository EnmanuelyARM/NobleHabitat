using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class VisitaRepository: Repository<Visita>, IVisitaRepository
    {
        public VisitaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Visita> GetByIdAsync(Guid id)
        {
            return await _dbContext.Visitas
                .Include(v => v.Propietario)
                .Include(v => v.Oficina)
                .FirstOrDefaultAsync(v => v.Id == id) 
                ?? throw new KeyNotFoundException($"Visita with id {id} not found.");
        }
        public async Task<IEnumerable<Visita>> GetAllWithPropietarioAndOficinaAsync()
        {
            return await _dbContext.Visitas
                .Include(v => v.Propietario)
                .Include(v => v.Oficina)
                .ToListAsync();
        }

        public Task<IEnumerable<Visita>> GetByInmuebleIdAsync(Guid inmuebleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Visita>> GetByClienteIdAsync(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
