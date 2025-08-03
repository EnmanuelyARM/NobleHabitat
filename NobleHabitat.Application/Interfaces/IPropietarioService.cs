using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IPropietarioService
    {
        Task<List<PropietarioDto>> GetPropietariosAsync();
        
        Task<PropietarioDto> GetPropietarioByIdAsync(Guid id);
        
        Task<PropietarioDto> CreatePropietarioAsync(PropietarioDto propietario);
        
        Task<PropietarioDto> UpdatePropietarioAsync(PropietarioDto propietario);
        
        Task DeletePropietarioAsync(Guid id);
    }
}
