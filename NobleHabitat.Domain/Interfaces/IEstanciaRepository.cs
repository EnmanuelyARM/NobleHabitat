using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IEstanciaRepository
    {
        Task<IEnumerable<Estancia>> GetByInmuebleIdAsync(Guid inmuebleId);
        Task AddAsync(Estancia estancia);
        Task DeleteAsync(Guid id);
    }

}
