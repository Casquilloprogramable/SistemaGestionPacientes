using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Application.Interfaces.Repositories;

public interface IPacienteRepository : IRepository<Paciente>
{
    Task<bool> ExisteDocumentoAsync(
        string documento,
        int? excluirId = null,
        CancellationToken cancellationToken = default);

    Task<bool> ExisteCorreoAsync(
        string correo,
        int? excluirId = null,
        CancellationToken cancellationToken = default);
}
