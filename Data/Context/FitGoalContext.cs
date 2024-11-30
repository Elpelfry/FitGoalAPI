using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data.Context;

public class FitGoalContext : DbContext
{
    public FitGoalContext(DbContextOptions<FitGoalContext> options) : base(options) { }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Rutinas> Rutinas { get; set; }
    public DbSet<RutinaEjercicios> RutinaEjercicios { get; set; }
    public DbSet<Ejercicios> Ejercicios { get; set; }
    public DbSet<ProgresoUsuarios> ProgresoUsuarios { get; set; }
    public DbSet<Tips> Tips { get; set; }
    public DbSet<HorarioBebidas> HorarioBebidas { get; set; }
}
