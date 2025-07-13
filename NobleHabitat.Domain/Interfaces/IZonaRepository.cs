using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IZonaRepository
    {
        Task<Zona?> GetByIdAsync(Guid id);
        Task<IEnumerable<Zona>> GetAllAsync();
    }

}
