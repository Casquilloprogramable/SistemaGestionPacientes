using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPacientes.Client.Models.Pacientes;

public class PacienteFormDTO
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

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    public string Telefono { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Correo { get; set; } = string.Empty;

    [Required]
    public DateTime FechaNacimiento { get; set; }
        = DateTime.Today.AddYears(-18);

    [Required]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    public string Sexo { get; set; } = string.Empty;
}