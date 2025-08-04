using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IVisitaService
    {
        Task<List<VisitaDto>> GetVisitasAsync();
        
        Task<VisitaDto> GetVisitaByIdAsync(Guid id);
        
        Task<VisitaDto> CreateVisitaAsync(VisitaDto visita);
        
        Task<VisitaDto> UpdateVisitaAsync(VisitaDto visita);
        
        Task DeleteVisitaAsync(Guid id);
    }
}
