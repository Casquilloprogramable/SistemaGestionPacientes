using SistemaGestionPacientes.Application.DTOs.Especialidades;

namespace SistemaGestionPacientes.Application.Interfaces.Services;

public interface IEspecialidadService
{
    Task<IEnumerable<EspecialidadDTO>> ObtenerTodosAsync();

    Task<EspecialidadDTO?> ObtenerPorIdAsync(int id);

    Task<EspecialidadDTO> CrearAsync(EspecialidadDTO dto);

    Task<EspecialidadDTO?> ActualizarAsync(int id, EspecialidadDTO dto);

    Task<bool> EliminarAsync(int id);
}