namespace SistemaGestionPacientes.Domain.Entities;

public class Consulta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Observaciones { get; set; } = string.Empty;

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    public int MedicoId { get; set; }
    public Medico? Medico { get; set; }

    public int CitaId { get; set; }
    public Cita? Cita { get; set; }

    public ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();
    public ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
    public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
}