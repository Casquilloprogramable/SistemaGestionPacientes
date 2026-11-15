using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPacientes.Application.DTOs.Especialidades;

public class EspecialidadDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Descripcion { get; set; } = string.Empty;
}