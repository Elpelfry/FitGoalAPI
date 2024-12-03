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
}
