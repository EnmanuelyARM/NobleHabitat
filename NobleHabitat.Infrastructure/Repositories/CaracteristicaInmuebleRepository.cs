using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class CaracteristicaInmuebleRepository: Repository<CaracteristicaInmueble>, ICaracteristicaInmuebleRepository
    {
        public CaracteristicaInmuebleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<CaracteristicaInmueble>> GetAllWithInmueblesAsync()
        {
            return await _dbContext.CaracteristicaInmuebles
                .Include(ci => ci.Inmueble)
                .ToListAsync();
        }
        public override async Task<CaracteristicaInmueble> GetByIdAsync(Guid id)
        {
            return await _dbContext.CaracteristicaInmuebles
                .Include(ci => ci.Inmueble)
                .FirstOrDefaultAsync(ci => ci.Id == id) 
                ?? throw new KeyNotFoundException($"CaracteristicaInmueble with id {id} not found.");
        }

        public async Task<IEnumerable<CaracteristicaInmueble>> GetByInmuebleIdAsync(Guid inmuebleId)
        {
            return await _dbContext.CaracteristicaInmuebles
                .Where(ci => ci.InmuebleId == inmuebleId)
                .ToListAsync();
        }
    }
}
