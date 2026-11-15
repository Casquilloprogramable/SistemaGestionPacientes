using SistemaGestionPacientes.Domain.Enums;

namespace SistemaGestionPacientes.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public EstadoUsuario Estado { get; set; } = EstadoUsuario.Activo;

    public int RolId { get; set; }
    public Rol? Rol { get; set; }
}