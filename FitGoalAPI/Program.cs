using FitGoalAPI.DAL;
using FitGoalAPI.Service;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(ConStr, new MySqlServerVersion(new Version(8, 0, 30))));

builder.Services.AddScoped<IUserService<Usuarios>, UsuariosService>();
builder.Services.AddScoped<IUserService<Entrenamientos>, EntrenamientosService>();
builder.Services.AddScoped<IUserService<ProgresoUsuarios>, ProgresoUsuariosService>();
builder.Services.AddScoped<IUserService<Rutinas>, RutinasService>();
builder.Services.AddScoped<IGenericService<Ejercicios>, EjerciciosService>();
builder.Services.AddScoped<IGenericService<Tips>, TipsService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(app => 
    app.AllowAnyOrigin().
            AllowAnyMethod().
                    AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();