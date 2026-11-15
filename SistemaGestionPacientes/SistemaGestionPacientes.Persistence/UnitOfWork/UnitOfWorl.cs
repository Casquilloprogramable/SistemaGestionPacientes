
using SistemaGestionPacientes.Application.Interfaces;
using SistemaGestionPacientes.Application.Interfaces.Repositories;
using SistemaGestionPacientes.Persistence.Context;
using SistemaGestionPacientes.Persistence.Repositories;
using SistemaGestionPacientes.Domain.Entities;

namespace SistemaGestionPacientes.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IPacienteRepository Pacientes { get; }
    public IRepository<Especialidad> Especialidades { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Pacientes = new PacienteRepository(context);

        Especialidades = new GenericRepository<Especialidad>(context);
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
