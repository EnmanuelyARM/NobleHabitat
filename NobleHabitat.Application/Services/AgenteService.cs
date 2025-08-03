using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class AgenteService : IAgenteService
    {
        private readonly IAgenteRepository _agenteRepository;
        public AgenteService(IAgenteRepository agenteRepository)
        {
            // Initialize the service with the repository
            // This constructor can be used to inject dependencies if needed
            _agenteRepository = agenteRepository ?? throw new ArgumentNullException(nameof(agenteRepository));
        }
        public async Task<AgenteDto> CreateAgentAsync(AgenteDto agentDto)
        {
            var agente = agentDto.Adapt<Agente>();
            await _agenteRepository.AddAsync(agente);

            return agente.Adapt<AgenteDto>();
        }
        public Task<AgenteDto> UpdateAgentAsync(AgenteDto agent)
        {
            var existingAgente = _agenteRepository.GetByIdAsync(agent.Id);
            if (existingAgente != null)
            {
                var updatedAgente = agent.Adapt<Agente>();
                _agenteRepository.UpdateAsync(updatedAgente);
                return Task.FromResult(updatedAgente.Adapt<AgenteDto>());
            }
            else
            {
                throw new KeyNotFoundException($"Agent with ID {agent.Id} not found.");
            }
        }

        public async Task<AgenteDto> DeleteAgentAsync(AgenteDto agent)
        {
            var agente = await _agenteRepository.GetByIdAsync(agent.Id);
            if (agente != null)
            {
                await _agenteRepository.DeleteAsync(agente.Id);
                return agente.Adapt<AgenteDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Agent with ID {agent.Id} not found.");
            }
        }

        public async Task<AgenteDto> GetAgentByIdAsync(Guid UsuarioId)
        {
            var agente = await  _agenteRepository.GetByUsuarioIdAsync(UsuarioId);
            if (agente != null)
            {
                return await Task.FromResult(agente.Adapt<AgenteDto>());
            }
            else
            {
                throw new KeyNotFoundException($"Agent with ID {UsuarioId} not found.");
            }
        }

        public async Task<List<AgenteDto>> GetAgentsAsync()
        {
            var agentes = await _agenteRepository.GetAllAsync();
            return await Task.FromResult(agentes.Adapt<List<AgenteDto>>());
        }

        public async Task DeleteAgentAsync(Guid usuarioId)
        {
            var agente = await _agenteRepository.GetByIdAsync(usuarioId);
            if (agente != null)
            {
                await _agenteRepository.DeleteAsync(usuarioId);
            }
            else
            {
                throw new KeyNotFoundException($"Agent with ID {usuarioId} not found.");
            }

        }
        
    }
}
