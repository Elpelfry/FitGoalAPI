using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class ProgresoUsuariosService(Context _context) : IUserService<ProgresoUsuarios>
{
    public async Task<List<ProgresoUsuarios>> GetListByUID(string usuarioId)
    {
        return await _context.ProgresoUsuarios.
            Where(p => p.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<ProgresoUsuarios> Get(string id)
    {
        var progreso = int.Parse(id);
        return (await _context.ProgresoUsuarios.FindAsync(progreso))!;
    }

    public async Task<ProgresoUsuarios> Add(ProgresoUsuarios progreso)
    {
        _context.ProgresoUsuarios.Add(progreso);
        await _context.SaveChangesAsync();
        return progreso;
    }

    public async Task<bool> Update(ProgresoUsuarios progreso)
    {
        _context.Entry(progreso).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var IdCast = int.Parse(id);
        var progreso = await _context.ProgresoUsuarios.FindAsync(IdCast);
        if (progreso == null)
        {
            return false;
        }
        _context.ProgresoUsuarios.Remove(progreso);
        return await _context.SaveChangesAsync() > 0;
    }
}