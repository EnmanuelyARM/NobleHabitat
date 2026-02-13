using NobleHabitat.Infrastructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infrastructure.Repositories
{
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _dbContext.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                ?? throw new KeyNotFoundException($"Usuario with id {id} not found.");
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbContext.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
