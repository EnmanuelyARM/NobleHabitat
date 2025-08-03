using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class OficinaServices : IOficinaService
    {
        private readonly IOficinaRepository _oficinaRepository;

        public OficinaServices(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository ?? throw new ArgumentNullException(nameof(oficinaRepository));
        }

        public async Task<List<OficinaDto>> GetOficinasAsync()
        {
            var oficinas = await _oficinaRepository.GetAllAsync();
            return oficinas.Adapt<List<OficinaDto>>();
        }

        public async Task<OficinaDto> GetOficinaByIdAsync(Guid id)
        {
            var oficina = await _oficinaRepository.GetByIdAsync(id);
            if (oficina != null)
            {
                return oficina.Adapt<OficinaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Oficina with ID {id} not found.");
            }
        }

        public async Task<OficinaDto> CreateOficinaAsync(OficinaDto oficinaDto)
        {
            var oficina = oficinaDto.Adapt<Oficina>();
            await _oficinaRepository.AddAsync(oficina);
            return oficina.Adapt<OficinaDto>();
        }

        public async Task<OficinaDto> UpdateOficinaAsync(OficinaDto oficinaDto)
        {
            var existing = await _oficinaRepository.GetByIdAsync(oficinaDto.Id);
            if (existing != null)
            {
                var updated = oficinaDto.Adapt<Oficina>();
                await _oficinaRepository.UpdateAsync(updated);
                return updated.Adapt<OficinaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Oficina with ID {oficinaDto.Id} not found.");
            }
        }

        public async Task DeleteOficinaAsync(Guid id)
        {
            var oficina = await _oficinaRepository.GetByIdAsync(id);
            if (oficina != null)
            {
                await _oficinaRepository.DeleteAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Oficina with ID {id} not found.");
            }



        }
    }
}