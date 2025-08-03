using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<ClienteDto> CreateClienteAsync(ClienteDto clienteDto)
        {
            var cliente = clienteDto.Adapt<Cliente>();
            await _clienteRepository.AddAsync(cliente);
            return cliente.Adapt<ClienteDto>();
        }

        public async Task DeleteClienteAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente with ID {id} not found.");

            await _clienteRepository.DeleteAsync(id);
        }

        public async Task<ClienteDto> GetClienteByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente with ID {id} not found.");

            return cliente.Adapt<ClienteDto>();
        }

        public async Task<List<ClienteDto>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Adapt<List<ClienteDto>>();
        }

        public async Task<ClienteDto> UpdateClienteAsync(ClienteDto clienteDto)
        {
            var existing = await _clienteRepository.GetByIdAsync(clienteDto.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Cliente with ID {clienteDto.Id} not found.");

            var updated = clienteDto.Adapt<Cliente>();
            await _clienteRepository.UpdateAsync(updated);
            return updated.Adapt<ClienteDto>();
        }
    }
}