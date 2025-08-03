using NobleHabitat.Application.Interfaces;
using NobleHabitat.Shared.DTOs;
using NobleHabitat.Domain.Interfaces;
using NobleHabitat.Domain.Entities;
using Mapster;

namespace NobleHabitat.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public async Task<List<UsuarioDto>> GetUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Adapt<List<UsuarioDto>>();
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario != null)
            {
                return usuario.Adapt<UsuarioDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Usuario with ID {id} not found.");
            }
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = usuarioDto.Adapt<Usuario>();
            await _usuarioRepository.AddAsync(usuario);
            return usuario.Adapt<UsuarioDto>();
        }

        public async Task<UsuarioDto> UpdateUsuarioAsync(UsuarioDto usuarioDto)
        {
            var existing = await _usuarioRepository.GetByIdAsync(usuarioDto.Id);
            if (existing != null)
            {
                var updated = usuarioDto.Adapt<Usuario>();
                await _usuarioRepository.UpdateAsync(updated);
                return updated.Adapt<UsuarioDto>();
            }
            else
            {
                throw new KeyNotFoundException($"Usuario with ID {usuarioDto.Id} not found.");
            }
        }

        public async Task DeleteUsuarioAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario != null)
            {
                await _usuarioRepository.DeleteAsync(id);
            }
            else
            {
                throw new KeyNotFoundException($"Usuario with ID {id} not found.");
            }
        }
    }
}