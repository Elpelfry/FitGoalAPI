using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class HorarioBebidasMapper
{
    public static HorarioBebidasDto ToDto(this HorarioBebidas horarioBebidas)
    {
        return new HorarioBebidasDto
        {
            HorarioBebidaId = horarioBebidas.HorarioBebidaId,
            UsuarioId = horarioBebidas.UsuarioId,
            Cantidad = horarioBebidas.Cantidad,
            Hora = horarioBebidas.Hora
        };
    }

    public static HorarioBebidas ToModel(this HorarioBebidasDto horarioBebidasDto)
    {
        return new HorarioBebidas
        {
            HorarioBebidaId = horarioBebidasDto.HorarioBebidaId,
            UsuarioId = horarioBebidasDto.UsuarioId,
            Cantidad = horarioBebidasDto.Cantidad,
            Hora = horarioBebidasDto.Hora
        };
    }
}