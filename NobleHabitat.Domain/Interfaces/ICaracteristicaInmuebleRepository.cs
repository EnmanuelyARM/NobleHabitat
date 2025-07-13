using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface ICaracteristicaInmuebleRepository
    {
        Task<IEnumerable<CaracteristicaInmueble>> GetByInmuebleIdAsync(Guid inmuebleId);
        Task AddAsync(CaracteristicaInmueble caracteristica);
        Task DeleteAsync(Guid id);
    }

}
