namespace SistemaGestionPacientes.Domain.Entities;

public class Tratamiento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public int ConsultaId { get; set; }
    public Consulta? Consulta { get; set; }
}