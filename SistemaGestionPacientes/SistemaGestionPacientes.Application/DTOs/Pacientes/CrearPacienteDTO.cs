using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPacientes.Application.DTOs.Pacientes;

public class CrearPacienteDTO
{
    [Required(ErrorMessage = "Los nombres son obligatorios")]
    [MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required(ErrorMessage = "El documento es obligatorio")]
    [MaxLength(20)]
    public string Documento { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "El correo no es válido")]
    public string Correo { get; set; } = string.Empty;

    [Required]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    public string Sexo { get; set; } = string.Empty;
}
