using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionPacientes.Application.Interfaces;
using SistemaGestionPacientes.Application.Interfaces.Repositories;
using SistemaGestionPacientes.Persistence.Context;
using SistemaGestionPacientes.Persistence.Repositories;

using UnitOfWorkImplementation =
    SistemaGestionPacientes.Persistence.UnitOfWork.UnitOfWork;

namespace SistemaGestionPacientes.Persistence.Extensions;

public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(
            "DefaultConnection")
            ?? "Data Source=SistemaGestionPacientes.db";

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IPacienteRepository, PacienteRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWorkImplementation>();

        return services;
    }
}