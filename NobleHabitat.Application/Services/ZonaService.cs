using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository _zonaRepository;

        public ZonaService(IZonaRepository zonaRepository)
        {
            _zonaRepository = zonaRepository ?? throw new ArgumentNullException(nameof(zonaRepository));
        }

        public async Task<List<ZonaDto>> GetZonasAsync()
        {
            var zonas = await _zonaRepository.GetAllAsync();
            return zonas.Adapt<List<ZonaDto>>();
        }

        public async Task<ZonaDto> GetZonaByIdAsync(Guid id)
        {
            var zona = await _zonaRepository.GetByIdAsync(id);
            if (zona != null)
            {
                return zona.Adapt<ZonaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Zona with ID {id} not found.");
            }            
        }

        public async Task<ZonaDto> CreateZonaAsync(ZonaDto zonaDto)
        {
            var zona = zonaDto.Adapt<Zona>();
            await _zonaRepository.AddAsync(zona);
            return zona.Adapt<ZonaDto>();
        }

        public async Task<ZonaDto> UpdateZonaAsync(ZonaDto zonaDto)
        {
            var existing = await _zonaRepository.GetByIdAsync(zonaDto.Id);
            if (existing != null)
            {
                var updated = zonaDto.Adapt<Zona>();
                await _zonaRepository.UpdateAsync(updated);
                return updated.Adapt<ZonaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Zona with ID {zonaDto.Id} not found.");
            }
        }

        public async Task DeleteZonaAsync(Guid id)
        {
            var zona = await _zonaRepository.GetByIdAsync(id);
            if (zona != null)
            {
                await _zonaRepository.DeleteAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Zona with ID {id} not found.");
            }            
        }
    }
}