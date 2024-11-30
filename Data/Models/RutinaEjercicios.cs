using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class RutinaEjercicios
{
    [Key]
    public int RutinaEjercicioId { get; set; }
    [ForeignKey("Rutinas")]
    public int RutinaId { get; set; }
    [ForeignKey("Ejercicios")]
    public int EjercicioId { get; set; }
    public int Repeticiones { get; set; }
    public int Series { get; set; }
}
