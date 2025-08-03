using NobleHabitat.Shared.DTOs;

namespace NobleHabitat.Application.Interfaces
{
    public interface ICaracteristicaInmuebleService
    {
        Task<List<CaracteristicaInmuebleDto>> GetCaracteristicasAsync();
        Task<CaracteristicaInmuebleDto> GetCaracteristicaByIdAsync(int id);
        Task<CaracteristicaInmuebleDto> CreateCaracteristicaAsync(CaracteristicaInmuebleDto caracteristica);
        Task<CaracteristicaInmuebleDto> UpdateCaracteristicaAsync(CaracteristicaInmuebleDto caracteristica);
        Task DeleteCaracteristicaAsync(int id);
    }
}
