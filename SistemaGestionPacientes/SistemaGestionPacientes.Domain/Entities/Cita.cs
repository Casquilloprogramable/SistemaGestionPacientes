using SistemaGestionPacientes.Domain.Enums;

namespace SistemaGestionPacientes.Domain.Entities;

public class Cita
{
    public int Id { get; set; }
    public DateTime FechaHora { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }

    public int MedicoId { get; set; }
    public Medico? Medico { get; set; }

    public Consulta? Consulta { get; set; }
}