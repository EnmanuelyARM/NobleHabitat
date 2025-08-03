using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IOficinaService
    {
        Task<List<OficinaDto>> GetOficinasAsync();
        
        Task<OficinaDto> GetOficinaByIdAsync(Guid id);
        
        Task<OficinaDto> CreateOficinaAsync(OficinaDto oficina);
        
        Task<OficinaDto> UpdateOficinaAsync(OficinaDto oficina);
        
        Task DeleteOficinaAsync(Guid id);
    }
}
