using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FitGoalAPI.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Rutinas> Rutinas { get; set; }
    public DbSet<RutinaEjercicios> RutinaEjercicios { get; set; }
    public DbSet<Ejercicios> Ejercicios { get; set; }
    public DbSet<Entrenamientos> Entrenamientos { get; set; }
    public DbSet<ProgresoUsuarios> ProgresoUsuarios { get; set; }
    public DbSet<Tips> Tips { get; set; }
}
