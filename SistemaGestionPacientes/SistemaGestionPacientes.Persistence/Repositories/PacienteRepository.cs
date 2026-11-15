using Microsoft.EntityFrameworkCore;
using SistemaGestionPacientes.Application.Interfaces.Repositories;
using SistemaGestionPacientes.Domain.Entities;
using SistemaGestionPacientes.Persistence.Context;

namespace SistemaGestionPacientes.Persistence.Repositories;

public class PacienteRepository :
    GenericRepository<Paciente>,
    IPacienteRepository
{
    public PacienteRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<bool> ExisteDocumentoAsync(
        string documento,
        int? excluirId = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Pacientes
            .AsNoTracking()
            .Where(p => p.Documento == documento);

        if (excluirId.HasValue)
        {
            query = query.Where(p => p.Id != excluirId.Value);
        }

        return await query.AnyAsync(cancellationToken);
    }

    public async Task<bool> ExisteCorreoAsync(
        string correo,
        int? excluirId = null,
        CancellationToken cancellationToken = default)
    {
        var correoNormalizado = correo.Trim().ToLower();

        var query = _context.Pacientes
            .AsNoTracking()
            .Where(p => p.Correo.ToLower() == correoNormalizado);

        if (excluirId.HasValue)
        {
            query = query.Where(p => p.Id != excluirId.Value);
        }

        return await query.AnyAsync(cancellationToken);
    }
}