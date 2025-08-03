using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IEstanciaService
    {
        Task<List<EstanciaDto>> GetEstanciasAsync();
        
        Task<EstanciaDto> GetEstanciaByIdAsync(Guid id);
        
        Task<EstanciaDto> CreateEstanciaAsync(EstanciaDto estancia);
        
        Task<EstanciaDto> UpdateEstanciaAsync(EstanciaDto estancia);
        
        Task DeleteEstanciaAsync(Guid id);
    }
}
