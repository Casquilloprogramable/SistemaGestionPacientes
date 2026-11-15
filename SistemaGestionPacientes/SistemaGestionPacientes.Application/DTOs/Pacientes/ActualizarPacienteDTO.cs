using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPacientes.Application.DTOs.Pacientes;

public class ActualizarPacienteDTO
{
    [Required]
    [MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Documento { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Correo { get; set; } = string.Empty;

    [Required]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    public string Sexo { get; set; } = string.Empty;
}