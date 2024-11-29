using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class RutinasMapper
{
    public static RutinasDto ToDto(this Rutinas rutinas)
    {
        return new RutinasDto
        {
            RutinaId = rutinas.RutinaId,
            UsuarioId = rutinas.UsuarioId,
            Nombre = rutinas.Nombre,
            Descripcion = rutinas.Descripcion,
            DuracionTotal = rutinas.DuracionTotal,
            RutinaEjercicios = rutinas.RutinaEjercicios.Select(re => re.ToDto()).ToList()
        };
    }

    public static Rutinas ToModel(this RutinasDto rutinasDto)
    {
        return new Rutinas
        {
            RutinaId = rutinasDto.RutinaId,
            UsuarioId = rutinasDto.UsuarioId,
            Nombre = rutinasDto.Nombre,
            Descripcion = rutinasDto.Descripcion,
            DuracionTotal = rutinasDto.DuracionTotal,
            RutinaEjercicios = rutinasDto.RutinaEjercicios.Select(reDto => reDto.ToModel()).ToList()
        };
    }
}
