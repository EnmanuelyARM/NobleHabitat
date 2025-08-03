using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IAgenteService
    {
        
        Task<List<AgenteDto>> GetAgentsAsync();
        
        Task<AgenteDto> GetAgentByIdAsync(Guid usuarioId);
        
        Task<AgenteDto> CreateAgentAsync(AgenteDto agent);
        
        Task<AgenteDto> UpdateAgentAsync(AgenteDto agent);
        
        Task DeleteAgentAsync(Guid usuarioId);
    }
}
