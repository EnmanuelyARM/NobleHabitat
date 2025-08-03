using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class EstanciaService: IEstanciaService
    {
        private readonly IEstanciaRepository _estanciaRepository;
        public EstanciaService(IEstanciaRepository estanciaRepository)
        {
            _estanciaRepository = estanciaRepository;
        }
        public async Task<EstanciaDto> GetEstanciaByIdAsync(Guid id)
        {
            var estancia = await _estanciaRepository.GetByInmuebleIdAsync(id);
            return estancia.Adapt<EstanciaDto>();
        }
        public async Task<IEnumerable<EstanciaDto>> GetAllEstanciasAsync()
        {
            var estancias = await _estanciaRepository.GetAllAsync();
            return estancias.Adapt<IEnumerable<EstanciaDto>>();
        }
        
        public async Task AddEstanciaAsync(EstanciaDto estanciaDto)
        {
            var estancia = estanciaDto.Adapt<Estancia>();
            await _estanciaRepository.AddAsync(estancia);
        }
        
        public async Task<EstanciaDto> UpdateEstanciaAsync(EstanciaDto estanciaDto)
        {
            var existing = await _estanciaRepository.GetByIdAsync(estanciaDto.Id);
            if (existing != null)
            {
                var updated = estanciaDto.Adapt<Estancia>();
                await _estanciaRepository.UpdateAsync(updated);
                return updated.Adapt<EstanciaDto>();
            }
            else {
                throw new KeyNotFoundException($"Estancia with ID {estanciaDto.Id} not found.");
            
            }   
            
        }        
        public async Task DeleteEstanciaAsync(Guid id)
        {
            await _estanciaRepository.DeleteAsync(id);
        }

        public async Task<List<EstanciaDto>> GetEstanciasAsync()
        {
            var estancias = await _estanciaRepository.GetAllAsync();
            return estancias.Adapt<List<EstanciaDto>>();
        }

        public async Task<EstanciaDto> CreateEstanciaAsync(EstanciaDto estanciaDto)
        {
            var estancia = estanciaDto.Adapt<Estancia>();
            await _estanciaRepository.AddAsync(estancia);
            return estancia.Adapt<EstanciaDto>();
        }

    }
}
