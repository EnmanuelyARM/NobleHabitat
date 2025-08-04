using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IInmuebleService
    {
        Task<List<InmuebleDto>> GetInmueblesAsync();
        
        Task<InmuebleDto> GetInmuebleByIdAsync(Guid id);
        
        Task<InmuebleDto> CreateInmuebleAsync(InmuebleDto inmueble);
        
        Task<InmuebleDto> UpdateInmuebleAsync(InmuebleDto inmueble);
        
        Task DeleteInmuebleAsync(Guid id);
    }
}
