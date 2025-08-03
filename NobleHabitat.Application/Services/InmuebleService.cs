using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class InmuebleService : IInmuebleService
    {
        private readonly IInmuebleRepository _inmuebleRepository;

        public InmuebleService(IInmuebleRepository inmuebleRepository)
        {
            _inmuebleRepository = inmuebleRepository ?? throw new ArgumentNullException(nameof(inmuebleRepository));
        }
        public async Task<List<InmuebleDto>> GetInmueblesAsync()
        {
            var inmuebles = await _inmuebleRepository.GetAllAsync();
            return inmuebles.Adapt<List<InmuebleDto>>();
        }
        public async Task<InmuebleDto> GetInmuebleByIdAsync(Guid id)
        {
            var inmueble = await _inmuebleRepository.GetByIdAsync(id);
            if (inmueble != null)
            {
                return inmueble.Adapt<InmuebleDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Inmueble with ID {id} not found.");
            }                        
        }
        public async Task<InmuebleDto> CreateInmuebleAsync(InmuebleDto inmuebleDto)
        {
            var inmueble = inmuebleDto.Adapt<Inmueble>();
            await _inmuebleRepository.AddAsync(inmueble);
            return inmueble.Adapt<InmuebleDto>();
        }
        public async Task<InmuebleDto> UpdateInmuebleAsync(InmuebleDto inmuebleDto)
        {
            var existing = await _inmuebleRepository.GetByIdAsync(inmuebleDto.Id);
            if (existing != null)
            {
                var updated = inmuebleDto.Adapt<Inmueble>();
                await _inmuebleRepository.UpdateAsync(updated);
                return updated.Adapt<InmuebleDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Inmueble with ID {inmuebleDto.Id} not found.");
            }
        }
        public async Task DeleteInmuebleAsync(Guid id)
        {
            var inmueble = await _inmuebleRepository.GetByIdAsync(id);
            if (inmueble != null)
            {
                await _inmuebleRepository.DeleteAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Inmueble with ID {id} not found.");
            }            
        }
    }
}
