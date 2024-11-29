using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Entrenamientos
{
    [Key]
    public int EntrenamientoId { get; set; }
    [ForeignKey("Usuarios")]
    public string? UsuarioId { get; set; }
    [ForeignKey("Rutinas")]
    public int RutinaId { get; set; }
    public DateTime Fecha { get; set; }
    public int DuracionTotal { get; set; }
    public string? Estado { get; set; }
}