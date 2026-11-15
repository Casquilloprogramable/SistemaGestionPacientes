using SistemaGestionPacientes.Application.DTOs.Pacientes;

namespace SistemaGestionPacientes.Application.Interfaces.Services;

public interface IPacienteService
{
    Task<IEnumerable<PacienteDTO>> ObtenerTodosAsync(
        CancellationToken cancellationToken = default);

    Task<PacienteDTO?> ObtenerPorIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<PacienteDTO> CrearAsync(
        CrearPacienteDTO dto,
        CancellationToken cancellationToken = default);

    Task<PacienteDTO?> ActualizarAsync(
        int id,
        ActualizarPacienteDTO dto,
        CancellationToken cancellationToken = default);

    Task<bool> EliminarAsync(
        int id,
        CancellationToken cancellationToken = default);
}