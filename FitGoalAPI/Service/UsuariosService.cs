using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class UsuariosService(Context _context) : IUserService<Usuarios>
{
    public async Task<List<Usuarios>> GetListByUID(string usuarioId)
    {
        return await _context.Usuarios.Where(u => u.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<Usuarios> Get(string usuarioId)
    {
        return (await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId))!;
    }

    public async Task<Usuarios> Add(Usuarios usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> Update(Usuarios usuario)
    {
        _context.Entry(usuario).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(string usuarioId)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
        if (usuario == null)
        {
            return false;
        }
        _context.Usuarios.Remove(usuario);
        return await _context.SaveChangesAsync() > 0;
    }
}