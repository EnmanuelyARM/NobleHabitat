using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IAgenteRepository
    {
        Task<Agente?> GetByUsuarioIdAsync(Guid usuarioId);
        Task<IEnumerable<Agente>> GetAllAsync();
    }

}
