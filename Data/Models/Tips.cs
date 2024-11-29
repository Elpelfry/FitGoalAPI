using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Tips
{
    [Key]
    public int TipId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
}
