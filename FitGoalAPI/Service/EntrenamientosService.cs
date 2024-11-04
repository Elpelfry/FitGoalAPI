using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class EntrenamientosService(Context _context) : IUserService<Entrenamientos>
{
    public async Task<List<Entrenamientos>> GetListByUID(string usuarioId)
    {
        return await _context.Entrenamientos.
            Where(e => e.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<Entrenamientos> Get(string id)
    {
        var entrenamiento = int.Parse(id);
        return (await _context.Entrenamientos.FindAsync(entrenamiento))!;
    }

    public async Task<Entrenamientos> Add(Entrenamientos entrenamiento)
    {
        _context.Entrenamientos.Add(entrenamiento);
        await _context.SaveChangesAsync();
        return entrenamiento;
    }

    public async Task<bool> Update(Entrenamientos entrenamiento)
    {
        _context.Entry(entrenamiento).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var IdCast = int.Parse(id);
        var entrenamiento = await _context.Entrenamientos.FindAsync(IdCast);
        if (entrenamiento == null)
        {
            return false;
        }
        _context.Entrenamientos.Remove(entrenamiento);
        return await _context.SaveChangesAsync() > 0;
    }
}