namespace Domain.DTO;

public class EntrenamientosDto
{
    public int EntrenamientoId { get; set; }
    public string? UsuarioId { get; set; }
    public int RutinaId { get; set; }
    public DateTime Fecha { get; set; }
    public int DuracionTotal { get; set; }
    public string? Estado { get; set; }
}
