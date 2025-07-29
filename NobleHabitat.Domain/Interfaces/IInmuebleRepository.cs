using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IInmuebleRepository : IRepository<Inmueble>
    {
        Task<IEnumerable<Inmueble>> GetByZonaAsync(Guid zonaId);
        Task<IEnumerable<Inmueble>> GetByTipoAsync(string tipo);
       
    }

}
