using SistemaGestionPacientes.Client.Models.Especialidades;

namespace SistemaGestionPacientes.Client.Services.Interfaces;

public interface IEspecialidadesApiService
{
    Task<List<EspecialidadDTO>> ObtenerTodosAsync();
    Task<EspecialidadDTO?> ObtenerPorIdAsync(int id);
    Task<EspecialidadDTO?> CrearAsync(EspecialidadDTO especialidad);
    Task<EspecialidadDTO?> ActualizarAsync(int id, EspecialidadDTO especialidad);
    Task EliminarAsync(int id);
}