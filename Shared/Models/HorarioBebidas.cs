﻿using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class HorarioBebidas
{
    [Key]
    public int HorarioBebidaId { get; set; }
    public string? UsuarioId { get; set; }
    public float Cantidad { get; set; }
    public string? Hora { get; set; }
}