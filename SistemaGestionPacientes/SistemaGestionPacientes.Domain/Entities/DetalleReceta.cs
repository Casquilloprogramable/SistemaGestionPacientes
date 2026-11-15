namespace SistemaGestionPacientes.Domain.Entities;

public class DetalleReceta
{
    public int Id { get; set; }
    public string Dosis { get; set; } = string.Empty;
    public string Frecuencia { get; set; } = string.Empty;
    public int DuracionDias { get; set; }

    public int RecetaId { get; set; }
    public Receta? Receta { get; set; }

    public int MedicamentoId { get; set; }
    public Medicamento? Medicamento { get; set; }
}