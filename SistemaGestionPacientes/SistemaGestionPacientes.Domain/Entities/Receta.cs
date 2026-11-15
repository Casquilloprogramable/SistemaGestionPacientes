namespace SistemaGestionPacientes.Domain.Entities;

public class Receta
{
    public int Id { get; set; }
    public DateTime FechaEmision { get; set; }
    public string IndicacionesGenerales { get; set; } = string.Empty;

    public int ConsultaId { get; set; }
    public Consulta? Consulta { get; set; }

    public ICollection<DetalleReceta> Detalles { get; set; }
        = new List<DetalleReceta>();
}
