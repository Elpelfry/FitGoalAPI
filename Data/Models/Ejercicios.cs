using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Ejercicios
{
    [Key]
    public int EjercicioId { get; set; }
    public string? NombreEjercicio { get; set; }
    public string? Descripcion { get; set; }
    public string? Foto { get; set; }
    public string? GrupoMuscular { get; set; }
}