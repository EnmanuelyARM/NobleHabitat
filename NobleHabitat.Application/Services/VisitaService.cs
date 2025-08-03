using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class VisitaService: IVisitaService
    {
        private readonly IVisitaRepository _visitaRepository;
        public VisitaService(IVisitaRepository visitaRepository)
        {
            _visitaRepository = visitaRepository ?? throw new ArgumentNullException(nameof(visitaRepository));
        }
        public async Task<List<VisitaDto>> GetVisitasAsync()
        {
            var visitas = await _visitaRepository.GetAllAsync();
            return visitas.Adapt<List<VisitaDto>>();
        }
        public async Task<VisitaDto> GetVisitaByIdAsync(Guid id)
        {
            var visita = await _visitaRepository.GetByIdAsync(id);
            if (visita != null)
            {
                return visita.Adapt<VisitaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Visita with ID {id} not found.");
            }
        }
        public async Task<VisitaDto> CreateVisitaAsync(VisitaDto visitaDto)
        {
            var visita = visitaDto.Adapt<Visita>();
            await _visitaRepository.AddAsync(visita);
            return visita.Adapt<VisitaDto>();
        }
        public async Task<VisitaDto> UpdateVisitaAsync(VisitaDto visitaDto)
        {
            var existing = await _visitaRepository.GetByIdAsync(visitaDto.Id);
            if (existing != null)
            {
                var updated = visitaDto.Adapt<Visita>();
                await _visitaRepository.UpdateAsync(updated);
                return updated.Adapt<VisitaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Visita with ID {visitaDto.Id} not found.");
            }
        }
        public async Task DeleteVisitaAsync(Guid id)
        {
            var visita = await _visitaRepository.GetByIdAsync(id);
            if (visita != null)
            {
                await _visitaRepository.DeleteAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Visita with ID {id} not found.");
            }
        }
    }
}
