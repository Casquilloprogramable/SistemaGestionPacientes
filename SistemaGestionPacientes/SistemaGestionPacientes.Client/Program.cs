using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SistemaGestionPacientes.Client;
using SistemaGestionPacientes.Client.Services;
using SistemaGestionPacientes.Client.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IEspecialidadesApiService, EspecialidadesApiService>();

// Dirección de nuestra API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5280/")
});

// Servicios
builder.Services.AddScoped<
    IPacientesApiService,
    PacientesApiService>();

await builder.Build().RunAsync();