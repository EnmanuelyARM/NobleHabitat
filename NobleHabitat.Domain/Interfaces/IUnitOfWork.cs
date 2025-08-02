
namespace NobleHabitat.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAgenteRepository Agentes { get; }
        IClienteRepository Clientes { get; }
        IPropietarioRepository Propietarios { get; }
        IUsuarioRepository Usuarios { get; }
        IInmuebleRepository Inmuebles { get; }
        IOficinaRepository Oficinas { get; }
        IZonaRepository Zonas { get; }
        ICaracteristicaInmuebleRepository CaracteristicaInmuebles { get; }
        IEstanciaRepository Estancias { get; }
        IVisitaRepository Visitas { get; }
        IOfertaRepository Ofertas { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
