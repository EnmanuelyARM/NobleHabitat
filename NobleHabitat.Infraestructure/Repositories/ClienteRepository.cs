using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _dbContext.clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente?> GetByUsuarioIdAsync(Guid usuarioId)
        {
            return await _dbContext.clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
        }
    }
}
