using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> GetUsuariosAsync();
        
        Task<UsuarioDto> GetUsuarioByIdAsync(Guid id);
        
        Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuario);
        
        Task<UsuarioDto> UpdateUsuarioAsync(UsuarioDto usuario);
        
        Task DeleteUsuarioAsync(Guid id);
    }
}
