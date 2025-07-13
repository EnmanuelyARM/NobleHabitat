using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IOfertaRepository
    {
        Task<Oferta?> GetByInmuebleIdAsync(Guid inmuebleId);
        Task AddAsync(Oferta oferta);
        Task UpdateAsync(Oferta oferta);
    }

}
