﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Usuarios
{
    [Key]
    public string? UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Correo { get; set; }
    public int Edad { get; set; }
    public float Altura { get; set; }
    public float PesoActual { get; set; }
    public float PesoIdeal { get; set; }
    public float AguaDiaria { get; set; }
}