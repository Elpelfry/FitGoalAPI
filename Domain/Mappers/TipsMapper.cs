using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class TipsMapper
{
    public static TipsDto ToDto(this Tips tips)
    {
        return new TipsDto
        {
            TipId = tips.TipId,
            Nombre = tips.Nombre,
            Descripcion = tips.Descripcion
        };
    }

    public static Tips ToModel(this TipsDto tipsDto)
    {
        return new Tips
        {
            TipId = tipsDto.TipId,
            Nombre = tipsDto.Nombre,
            Descripcion = tipsDto.Descripcion
        };
    }
}