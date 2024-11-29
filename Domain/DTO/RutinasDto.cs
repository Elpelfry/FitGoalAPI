namespace Domain.DTO;

public class RutinasDto
{
    public int RutinaId { get; set; }
    public string? UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public int DuracionTotal { get; set; }
    public ICollection<RutinaEjerciciosDto> RutinaEjercicios { get; set; } = new List<RutinaEjerciciosDto>();
}
