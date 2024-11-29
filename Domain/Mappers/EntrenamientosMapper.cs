using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class EntrenamientosMapper
{
    public static EntrenamientosDto ToDto(this Entrenamientos entrenamiento)
    {
        return new EntrenamientosDto
        {
            EntrenamientoId = entrenamiento.EntrenamientoId,
            UsuarioId = entrenamiento.UsuarioId,
            RutinaId = entrenamiento.RutinaId,
            Fecha = entrenamiento.Fecha,
            DuracionTotal = entrenamiento.DuracionTotal,
            Estado = entrenamiento.Estado
        };
    }

    public static Entrenamientos ToModel(this EntrenamientosDto entrenamientosDto)
    {
        return new Entrenamientos
        {
            EntrenamientoId = entrenamientosDto.EntrenamientoId,
            UsuarioId = entrenamientosDto.UsuarioId,
            RutinaId = entrenamientosDto.RutinaId,
            Fecha = entrenamientosDto.Fecha,
            DuracionTotal = entrenamientosDto.DuracionTotal,
            Estado = entrenamientosDto.Estado
        };
    }
}