//using NobleHabitat.Application.Interfaces;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Infraestructure.Data;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;

        public IAgenteRepository Agentes { get; }
        public ICaracteristicaInmuebleRepository CaracteristicaInmuebles { get; }
        public IClienteRepository Clientes { get; }
        public IEstanciaRepository Estancias { get; }
        public IInmuebleRepository Inmuebles { get; }
        public IOfertaRepository Ofertas { get; }
        public IOficinaRepository Oficinas { get; }
        public IPropietarioRepository Propietarios { get; }
        public IUsuarioRepository Usuarios { get; }
        public IVisitaRepository Visitas { get; }
        public IZonaRepository Zonas { get; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;

            Agentes = new AgenteRepository(_dbContext);
            CaracteristicaInmuebles = new CaracteristicaInmuebleRepository(_dbContext);
            Clientes = new ClienteRepository(_dbContext);
            Estancias = new EstanciaRepository(_dbContext);
            Inmuebles = new InmuebleRepository(_dbContext);
            Ofertas = new OfertaRepository(_dbContext);
            Oficinas = new OficinaRepository(_dbContext);
            Propietarios = new PropietarioRepository(_dbContext);
            Usuarios = new UsuarioRepository(_dbContext);
            Visitas = new VisitaRepository(_dbContext);
            Zonas = new ZonaRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}