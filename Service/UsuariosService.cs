using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class UsuariosService(FitGoalContext _context) : IUsuarioService
{
    public async Task<UsuariosDto> Get(string id)
    {
        return (await _context.Usuarios.FindAsync(id))!.ToDto();
    }

    public async Task<UsuariosDto> Add(UsuariosDto usuario)
    {
        var model = usuario.ToModel();
        _context.Usuarios.Add(model);
        await _context.SaveChangesAsync();
        return model.ToDto();
    }

    public async Task<bool> Update(UsuariosDto usuario)
    {
        _context.Entry(usuario.ToModel()).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return false;
        }
        _context.Usuarios.Remove(usuario);
        return await _context.SaveChangesAsync() > 0;
    }
}