namespace Domain.DTO;

public class ProgresoUsuariosDto
{
    public int ProgresoId { get; set; }
    public string? UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public float Peso { get; set; }
    public float Brazo { get; set; }
    public float Pierna { get; set; }
    public float Pecho { get; set; }
    public float Cintura { get; set; }
}
