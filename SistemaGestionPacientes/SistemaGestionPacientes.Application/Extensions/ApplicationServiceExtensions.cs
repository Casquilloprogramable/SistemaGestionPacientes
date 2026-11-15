using Microsoft.Extensions.DependencyInjection;
using SistemaGestionPacientes.Application.Interfaces.Services;
using SistemaGestionPacientes.Application.Services;

namespace SistemaGestionPacientes.Application.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IPacienteService, PacienteService>();
        services.AddScoped<IEspecialidadService, EspecialidadService>();

        return services;
    }
}