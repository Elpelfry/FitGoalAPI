﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Rutinas
{
    [Key]
    public int RutinaId { get; set; }
    [ForeignKey("Usuarios")]
    public string? UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public TimeSpan DuracionTotal { get; set; }
    [ForeignKey("RutinaId")]
    public ICollection<RutinaEjercicios> RutinaEjercicios { get; set; } = new List<RutinaEjercicios>();
}