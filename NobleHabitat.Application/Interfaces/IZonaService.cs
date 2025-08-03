using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IZonaService
    {
        Task<List<ZonaDto>> GetZonasAsync();
        
        Task<ZonaDto> GetZonaByIdAsync(Guid id);
        
        Task<ZonaDto> CreateZonaAsync(ZonaDto zona);
        
        Task<ZonaDto> UpdateZonaAsync(ZonaDto zona);
        
        Task DeleteZonaAsync(Guid id);
    }
}
