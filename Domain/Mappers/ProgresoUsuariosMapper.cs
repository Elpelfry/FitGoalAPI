using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class ProgresoUsuariosMapper
{
    public static ProgresoUsuariosDto ToDto(this ProgresoUsuarios progresoUsuarios)
    {
        return new ProgresoUsuariosDto
        {
            ProgresoId = progresoUsuarios.ProgresoId,
            UsuarioId = progresoUsuarios.UsuarioId,
            Fecha = progresoUsuarios.Fecha,
            Peso = progresoUsuarios.Peso
        };
    }

    public static ProgresoUsuarios ToModel(this ProgresoUsuariosDto progresoUsuariosDto)
    {
        return new ProgresoUsuarios
        {
            ProgresoId = progresoUsuariosDto.ProgresoId,
            UsuarioId = progresoUsuariosDto.UsuarioId,
            Fecha = progresoUsuariosDto.Fecha,
            Peso = progresoUsuariosDto.Peso
        };
    }
}