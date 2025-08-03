using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly IOfertaRepository _ofertaRepository;

        public OfertaService(IOfertaRepository ofertaRepository)
        {
            _ofertaRepository = ofertaRepository ?? throw new ArgumentNullException(nameof(ofertaRepository));
        }

        public async Task<List<OfertaDto>> GetOfertasAsync()
        {
            var ofertas = await _ofertaRepository.GetAllAsync();
            return ofertas.Adapt<List<OfertaDto>>();
        }

        public async Task<OfertaDto> GetOfertaByIdAsync(Guid id)
        {
            var oferta = await _ofertaRepository.GetByIdAsync(id);
            if (oferta != null)
            {
                return oferta.Adapt<OfertaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Oferta with ID {id} not found.");                
            }            
        }

        public async Task<OfertaDto> CreateOfertaAsync(OfertaDto ofertaDto)
        {
            var oferta = ofertaDto.Adapt<Oferta>();
            await _ofertaRepository.AddAsync(oferta);
            return oferta.Adapt<OfertaDto>();
        }

        public async Task<OfertaDto> UpdateOfertaAsync(OfertaDto ofertaDto)
        {
            var existing = await _ofertaRepository.GetByIdAsync(ofertaDto.Id);
            if (existing != null)
            {
                var updated = ofertaDto.Adapt<Oferta>();
                await _ofertaRepository.UpdateAsync(updated);
                return updated.Adapt<OfertaDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Oferta with ID {ofertaDto.Id} not found.");                
            }            
        }

        public async Task DeleteOfertaAsync(Guid id)
        {
            var oferta = await _ofertaRepository.GetByIdAsync(id);
            if (oferta != null)
            {
                await _ofertaRepository.DeleteAsync(id);
            } 
            else
            {
                throw new KeyNotFoundException($"Oferta with ID {id} not found.");
            }            
        }
    }
}