using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAgenteRepository AgenteRepository { get; }
        IOficinaRepository OficinaRepository { get; }
        IPropietarioRepository PropietarioRepository { get; }
        IZonaRepository ZonaRepository { get; }
        ICaracteristicaInmuebleRepository CaracteristicaInmuebleRepository { get; }
        IInmuebleRepository InmuebleRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IOfertaRepository OfertaRepository { get; }
        IVisitaRepository VisitaRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IEstanciaRepository EstanciaRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
