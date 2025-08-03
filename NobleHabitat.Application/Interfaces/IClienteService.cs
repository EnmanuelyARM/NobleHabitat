using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> GetClientesAsync();
        
        Task<ClienteDto> GetClienteByIdAsync(Guid id);
        
        Task<ClienteDto> CreateClienteAsync(ClienteDto cliente);
        
        Task<ClienteDto> UpdateClienteAsync(ClienteDto cliente);
        
        Task DeleteClienteAsync(Guid id);
    }
}
