using NobleHabitat.Shared.DTOs;
using System.Net.Http.Json;

namespace NobleHabitat.WebUI.Services
{
    public class InmuebleServiceClient
    {
        private readonly HttpClient _httpClient;

        public InmuebleServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<List<InmuebleDto>> GetInmueblesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<InmuebleDto>>("api/inmueble")
                   ?? new List<InmuebleDto>();
        }

        
        public async Task<InmuebleDto?> GetInmuebleByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<InmuebleDto>($"api/inmueble/{id}");
        }

        
        public async Task<bool> CrearInmuebleAsync(InmuebleDto nuevoInmueble)
        {
            var response = await _httpClient.PostAsJsonAsync("api/inmueble", nuevoInmueble);
            return response.IsSuccessStatusCode;
        }

        
        public async Task<bool> ActualizarInmuebleAsync(Guid id, InmuebleDto inmueble)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/inmueble/{id}", inmueble);
            return response.IsSuccessStatusCode;
        }

        
        public async Task<bool> EliminarInmuebleAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/inmueble/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
