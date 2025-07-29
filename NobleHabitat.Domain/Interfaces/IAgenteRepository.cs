using NobleHabitat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IAgenteRepository : IRepository<Agente>
    {
        Task<Agente?> GetByUsuarioIdAsync(Guid UsuarioId);
    }

}
