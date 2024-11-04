using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class RutinasService(Context _context) : IUserService<Rutinas>
{
    public async Task<List<Rutinas>> GetListByUID(string usuarioId)
    {
        return await _context.Rutinas.
            Where(r => r.UsuarioId == usuarioId).
                Include(d => d.RutinaEjercicios).ToListAsync();
    }

    public async Task<Rutinas> Get(string id)
    {
        var rutina = int.Parse(id);
        return (await _context.Rutinas.Include(d => d.RutinaEjercicios).
                FirstOrDefaultAsync(r => r.RutinaId == rutina))!;
    }

    public async Task<Rutinas> Add(Rutinas rutina)
    {
        _context.Rutinas.Add(rutina);
        await _context.SaveChangesAsync();
        return rutina;
    }

    public async Task<bool> Update(Rutinas rutina)
    {
        _context.Entry(rutina).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var IdCast = int.Parse(id);
        var rutina = await _context.Rutinas.FindAsync(IdCast);
        if (rutina == null)
        {
            return false;
        }
        await _context.RutinaEjercicios.
            Where(RE => RE.RutinaId == IdCast).ExecuteDeleteAsync();
        _context.Rutinas.Remove(rutina);
        return await _context.SaveChangesAsync() > 0;
    }
}