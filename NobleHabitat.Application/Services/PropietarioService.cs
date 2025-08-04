using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class PropietarioService : IPropietarioService
    {
        private readonly IPropietarioRepository _propietarioRepository;
        public PropietarioService(IPropietarioRepository propietarioRepository)
        {
            _propietarioRepository = propietarioRepository ?? throw new ArgumentNullException(nameof(propietarioRepository));
        }
        public async Task<List<PropietarioDto>> GetPropietariosAsync()
        {
            var propietarios = await _propietarioRepository.GetAllAsync();
            return propietarios.Adapt<List<PropietarioDto>>();
        }
        public async Task<PropietarioDto> GetPropietarioByIdAsync(Guid id)
        {
            var propietario = await _propietarioRepository.GetByIdAsync(id);
            if (propietario != null)
            {
                return propietario.Adapt<PropietarioDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Propietario with ID {id} not found.");
            }
        }
        public async Task<PropietarioDto> CreatePropietarioAsync(PropietarioDto propietarioDto)
        {
            var propietario = propietarioDto.Adapt<Propietario>();
            await _propietarioRepository.AddAsync(propietario);
            return propietario.Adapt<PropietarioDto>();
        }
        public async Task<PropietarioDto> UpdatePropietarioAsync(PropietarioDto propietarioDto)
        {
            var existing = await _propietarioRepository.GetByIdAsync(propietarioDto.Id);
            if (existing != null)
            {
                var updated = propietarioDto.Adapt<Propietario>();
                await _propietarioRepository.UpdateAsync(updated);
                return updated.Adapt<PropietarioDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Propietario with ID {propietarioDto.Id} not found.");
            }
        }
        public async Task DeletePropietarioAsync(Guid id)
        {
            var propietario = await _propietarioRepository.GetByIdAsync(id);
            if (propietario != null)
            {
                await _propietarioRepository.DeleteAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Propietario with ID {id} not found.");
            }
        }
    }

}
