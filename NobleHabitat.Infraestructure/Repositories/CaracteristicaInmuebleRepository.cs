using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class CaracteristicaInmuebleRepository: Repository<CaracteristicaInmueble>, ICaracteristicaInmuebleRepository
    {
        public CaracteristicaInmuebleRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<CaracteristicaInmueble>> GetAllWithInmueblesAsync()
        {
            return await _dbContext.caracteristicaInmuebles
                .Include(ci => ci.Inmueble)
                .ToListAsync();
        }
        public async Task<CaracteristicaInmueble> GetByIdAsync(Guid id)
        {
            return await _dbContext.caracteristicaInmuebles
                .Include(ci => ci.Inmueble)
                .FirstOrDefaultAsync(ci => ci.Id == id) 
                ?? throw new KeyNotFoundException($"CaracteristicaInmueble with id {id} not found.");
        }

        public async Task<IEnumerable<CaracteristicaInmueble>> GetByInmuebleIdAsync(Guid inmuebleId)
        {
            return await _dbContext.caracteristicaInmuebles
                .Where(ci => ci.InmuebleId == inmuebleId)
                .ToListAsync();
        }
    }
}
