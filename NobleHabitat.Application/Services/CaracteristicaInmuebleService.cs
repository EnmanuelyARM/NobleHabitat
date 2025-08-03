using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class CaracteristicaInmuebleService: ICaracteristicaInmuebleService
    {
        private readonly ICaracteristicaInmuebleRepository _caracteristicaInmuebleRepository;
        public CaracteristicaInmuebleService(ICaracteristicaInmuebleRepository caracteristicaInmuebleRepository)
        {
            _caracteristicaInmuebleRepository = caracteristicaInmuebleRepository ?? throw new ArgumentNullException(nameof(caracteristicaInmuebleRepository));
        }
        public async Task<CaracteristicaInmuebleDto> CreateCaracteristicaAsync(CaracteristicaInmuebleDto caracteristicaDto)
        {
            var caracteristica = caracteristicaDto.Adapt<CaracteristicaInmueble>();
            await _caracteristicaInmuebleRepository.AddAsync(caracteristica);
            return caracteristica.Adapt<CaracteristicaInmuebleDto>();
        }
        public async Task<CaracteristicaInmuebleDto> UpdateCaracteristicaAsync(CaracteristicaInmuebleDto caracteristicaDto)
        {
            var existingCaracteristica = await _caracteristicaInmuebleRepository.GetByIdAsync(caracteristicaDto.Id);
            if (existingCaracteristica != null)
            {
                var updatedCaracteristica = caracteristicaDto.Adapt<CaracteristicaInmueble>();
                await _caracteristicaInmuebleRepository.UpdateAsync(updatedCaracteristica);
                return updatedCaracteristica.Adapt<CaracteristicaInmuebleDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Characteristic with ID {caracteristicaDto.Id} not found.");
            }
        }
        public async Task<CaracteristicaInmuebleDto> DeleteCaracteristicaAsync(CaracteristicaInmuebleDto caracteristicaDto)
        {
            var caracteristica = await _caracteristicaInmuebleRepository.GetByIdAsync(caracteristicaDto.Id);
            if (caracteristica != null)
            {
                await _caracteristicaInmuebleRepository.DeleteAsync(caracteristica.Id);
                return caracteristica.Adapt<CaracteristicaInmuebleDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Characteristic with ID {caracteristicaDto.Id} not found.");
            }
        }
        public async Task<List<CaracteristicaInmuebleDto>> GetAllAsync()
        {
            var caracteristicas = await _caracteristicaInmuebleRepository.GetAllAsync();
            return caracteristicas.Adapt<List<CaracteristicaInmuebleDto>>();
        }

        public Task<List<CaracteristicaInmuebleDto>> GetCaracteristicasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CaracteristicaInmuebleDto> GetCaracteristicaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCaracteristicaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
