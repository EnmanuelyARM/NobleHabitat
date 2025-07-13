using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IInmuebleRepository
    {
        Task<Inmueble?> GetByIdAsync(Guid id);
        Task<IEnumerable<Inmueble>> GetAllAsync();
        Task<IEnumerable<Inmueble>> GetByZonaAsync(Guid zonaId);
        Task<IEnumerable<Inmueble>> GetByTipoAsync(string tipo);
        Task AddAsync(Inmueble inmueble);
        Task UpdateAsync(Inmueble inmueble);
        Task DeleteAsync(Guid id);
    }

}
