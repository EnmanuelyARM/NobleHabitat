using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface IOfertaService
    {
        Task<List<OfertaDto>> GetOfertasAsync();
        
        Task<OfertaDto> GetOfertaByIdAsync(Guid id);
        
        Task<OfertaDto> CreateOfertaAsync(OfertaDto oferta);
        
        Task<OfertaDto> UpdateOfertaAsync(OfertaDto oferta);
        
        Task DeleteOfertaAsync(Guid id);
    }
}
