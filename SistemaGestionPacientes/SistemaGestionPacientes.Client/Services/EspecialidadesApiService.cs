using System.Net.Http.Json;
using SistemaGestionPacientes.Client.Models.Especialidades;
using SistemaGestionPacientes.Client.Services.Interfaces;

namespace SistemaGestionPacientes.Client.Services;

public class EspecialidadesApiService : IEspecialidadesApiService
{
    private readonly HttpClient _http;

    public EspecialidadesApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<EspecialidadDTO>> ObtenerTodosAsync()
    {
        return await _http.GetFromJsonAsync<List<EspecialidadDTO>>(
            "api/v1/Especialidades") ?? new();
    }

    public async Task<EspecialidadDTO?> ObtenerPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<EspecialidadDTO>(
            $"api/v1/Especialidades/{id}");
    }

    public async Task<EspecialidadDTO?> CrearAsync(EspecialidadDTO especialidad)
    {
        var response = await _http.PostAsJsonAsync(
            "api/v1/Especialidades", especialidad);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<EspecialidadDTO>();
    }

    public async Task<EspecialidadDTO?> ActualizarAsync(
        int id, EspecialidadDTO especialidad)
    {
        var response = await _http.PutAsJsonAsync(
            $"api/v1/Especialidades/{id}", especialidad);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<EspecialidadDTO>();
    }

    public async Task EliminarAsync(int id)
    {
        var response = await _http.DeleteAsync(
            $"api/v1/Especialidades/{id}");

        response.EnsureSuccessStatusCode();
    }
}