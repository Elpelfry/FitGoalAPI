using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class RutinaEjerciciosMapper
{
    public static RutinaEjerciciosDto ToDto(this RutinaEjercicios rutinaEjercicios)
    {
        return new RutinaEjerciciosDto
        {
            RutinaEjercicioId = rutinaEjercicios.RutinaEjercicioId,
            RutinaId = rutinaEjercicios.RutinaId,
            EjercicioId = rutinaEjercicios.EjercicioId,
            Repeticiones = rutinaEjercicios.Repeticiones,
            Series = rutinaEjercicios.Series,
            Descanso = rutinaEjercicios.Descanso
        };
    }

    public static RutinaEjercicios ToModel(this RutinaEjerciciosDto rutinaEjerciciosDto)
    {
        return new RutinaEjercicios
        {
            RutinaEjercicioId = rutinaEjerciciosDto.RutinaEjercicioId,
            RutinaId = rutinaEjerciciosDto.RutinaId,
            EjercicioId = rutinaEjerciciosDto.EjercicioId,
            Repeticiones = rutinaEjerciciosDto.Repeticiones,
            Series = rutinaEjerciciosDto.Series,
            Descanso = rutinaEjerciciosDto.Descanso
        };
    }
}