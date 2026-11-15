namespace SistemaGestionPacientes.Domain.Entities;

public class Medicamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Presentacion { get; set; } = string.Empty;

    public ICollection<DetalleReceta> DetallesReceta { get; set; }
        = new List<DetalleReceta>();
}