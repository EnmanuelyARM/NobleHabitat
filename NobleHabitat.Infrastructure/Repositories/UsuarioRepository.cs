using NobleHabitat.Infraestructure.Data;
using NobleHabitat.Domain.Entities;
using NobleHabitat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Repositories
{
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _dbContext.usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                ?? throw new KeyNotFoundException($"Usuario with id {id} not found.");
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbContext.usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
