using Microsoft.Extensions.DependencyInjection;
using Abstractions;
using Data.DI;
using Microsoft.Extensions.Configuration;

namespace Service.DI;

public static class ServicesRegister
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEjercicioService, EjerciciosService>();
        services.AddScoped<IHorarioBebidaService, HorarioBebidasService>();
        services.AddScoped<IProgresoUsuarioService, ProgresoUsuariosService>();
        services.AddScoped<IRutinaService, RutinasService>();
        services.AddScoped<ITipService, TipsService>();
        services.AddScoped<IUsuarioService, UsuariosService>();
        return services;
    }
}
