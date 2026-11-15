using SistemaGestionPacientes.Client.Models.Pacientes;

namespace SistemaGestionPacientes.Client.Services.Interfaces;

public interface IPacientesApiService
{
    Task<List<PacienteDTO>> ObtenerTodosAsync();

    Task<bool> CrearAsync(PacienteFormDTO paciente);

    Task<bool> ActualizarAsync(int id, PacienteFormDTO paciente);

    Task<bool> EliminarAsync(int id);
}