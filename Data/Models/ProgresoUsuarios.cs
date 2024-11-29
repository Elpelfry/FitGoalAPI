using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class ProgresoUsuarios
{
    [Key]
    public int ProgresoId { get; set; }
    [ForeignKey("Usuarios")]
    public string? UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public float Peso { get; set; }
    public float Brazo { get; set; }
    public float Pierna { get; set; }
    public float Pecho { get; set; }
    public float Cintura { get; set; }
}
