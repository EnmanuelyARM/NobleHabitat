using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class InmuebleRepository: Repository<Inmueble>, IInmuebleRepository
    {
        public InmuebleRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Inmueble>> GetAllWithCaracteristicasAsync()
        {
            return await _dbContext.inmuebles
                .Include(i => i.Caracteristicas)
                .ToListAsync();
        }
        public async Task<Inmueble> GetByIdAsync(Guid id)
        {
            return await _dbContext.inmuebles
                .Include(i => i.Caracteristicas)
                .FirstOrDefaultAsync(i => i.Id == id) 
                ?? throw new KeyNotFoundException($"Inmueble with id {id} not found.");
        }

        public async Task<IEnumerable<Inmueble>> GetByTipoAsync(string tipo)
        {
            return await Task.FromResult<IEnumerable<Inmueble>>(
                _dbContext.inmuebles
                    .Where(i => i.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase))
                    .AsEnumerable());
        }

        public async Task<IEnumerable<Inmueble>> GetByZonaAsync(Guid zonaId)
        {
            return await _dbContext.inmuebles
                .Where(i => i.ZonaId == zonaId)
                .ToListAsync();
        }
    }
    {
    }
}
