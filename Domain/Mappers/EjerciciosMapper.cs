using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class EjerciciosMapper
{
    public static EjerciciosDto ToDto(this Ejercicios ejercicio)
    {
        return new EjerciciosDto
        {
            EjercicioId = ejercicio.EjercicioId,
            NombreEjercicio = ejercicio.NombreEjercicio,
            Descripcion = ejercicio.Descripcion,
            Foto = ejercicio.Foto,
            GrupoMuscular = ejercicio.GrupoMuscular
        };
    }

    public static Ejercicios ToModel(this EjerciciosDto ejerciciosDto)
    {
        return new Ejercicios
        {
            EjercicioId = ejerciciosDto.EjercicioId,
            NombreEjercicio = ejerciciosDto.NombreEjercicio,
            Descripcion = ejerciciosDto.Descripcion,
            Foto = ejerciciosDto.Foto,
            GrupoMuscular = ejerciciosDto.GrupoMuscular
        };
    }
}