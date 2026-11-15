using SistemaGestionPacientes.Application.Interfaces.Repositories;
using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPacienteRepository Pacientes { get; }
    IRepository<Especialidad> Especialidades { get; }
    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}