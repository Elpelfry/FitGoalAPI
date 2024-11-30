using Data.Models;
using Domain.DTO;

namespace Domain.Mappers;

public static class UsuariosMapper
{
    public static UsuariosDto ToDto(this Usuarios usuarios)
    {
        return new UsuariosDto
        {
            UsuarioId = usuarios.UsuarioId,
            Nombre = usuarios.Nombre,
            Apellido = usuarios.Apellido,
            Correo = usuarios.Correo,
            Edad = usuarios.Edad,
            Altura = usuarios.Altura,
            PesoActual = usuarios.PesoActual,
            PesoIdeal = usuarios.PesoIdeal,
            PesoInicial = usuarios.PesoInicial,
            AguaDiaria = usuarios.AguaDiaria
        };
    }

    public static Usuarios ToModel(this UsuariosDto usuariosDto)
    {
        return new Usuarios
        {
            UsuarioId = usuariosDto.UsuarioId,
            Nombre = usuariosDto.Nombre,
            Apellido = usuariosDto.Apellido,
            Correo = usuariosDto.Correo,
            Edad = usuariosDto.Edad,
            Altura = usuariosDto.Altura,
            PesoActual = usuariosDto.PesoActual,
            PesoIdeal = usuariosDto.PesoIdeal,
            PesoInicial = usuariosDto.PesoInicial,
            AguaDiaria = usuariosDto.AguaDiaria
        };
    }
}