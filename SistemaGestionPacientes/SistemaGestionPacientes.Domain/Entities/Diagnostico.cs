namespace SistemaGestionPacientes.Domain.Entities;

public class Diagnostico
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string Observaciones { get; set; } = string.Empty;

    public int ConsultaId { get; set; }
    public Consulta? Consulta { get; set; }
}