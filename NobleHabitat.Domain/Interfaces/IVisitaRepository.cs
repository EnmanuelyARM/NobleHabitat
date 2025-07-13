using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IVisitaRepository
    {
        Task<Visita?> GetByIdAsync(Guid id);
        Task<IEnumerable<Visita>> GetByInmuebleIdAsync(Guid inmuebleId);
        Task<IEnumerable<Visita>> GetByClienteIdAsync(Guid clienteId);
        Task AddAsync(Visita visita);
    }

}
