using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _dbContext.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente?> GetByUsuarioIdAsync(Guid usuarioId)
        {
            return await _dbContext.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
        }
    }
}
