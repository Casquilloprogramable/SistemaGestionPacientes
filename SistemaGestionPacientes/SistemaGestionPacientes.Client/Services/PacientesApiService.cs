using System.Net.Http.Json;
using SistemaGestionPacientes.Client.Models.Pacientes;
using SistemaGestionPacientes.Client.Services.Interfaces;

namespace SistemaGestionPacientes.Client.Services;

public class PacientesApiService : IPacientesApiService
{
    private readonly HttpClient _httpClient;

    private const string Endpoint = "api/v1/Pacientes";

    public PacientesApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PacienteDTO>> ObtenerTodosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<PacienteDTO>>(
            Endpoint) ?? new List<PacienteDTO>();
    }

    public async Task<bool> CrearAsync(PacienteFormDTO paciente)
    {
        var response = await _httpClient.PostAsJsonAsync(
            Endpoint, paciente);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ActualizarAsync(
        int id, PacienteFormDTO paciente)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"{Endpoint}/{id}", paciente);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var response = await _httpClient.DeleteAsync(
            $"{Endpoint}/{id}");

        return response.IsSuccessStatusCode;
    }
}