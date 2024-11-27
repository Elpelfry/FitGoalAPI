using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class HorarioBebidasService(Context _context) : IUserService<HorarioBebidas>
{
    public async Task<List<HorarioBebidas>> GetListByUID(string usuarioId)
    {
        return await _context.HorarioBebidas.
            Where(h => h.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<HorarioBebidas> Get(string id)
    {
        var horario = int.Parse(id);
        return (await _context.HorarioBebidas.FirstOrDefaultAsync(h => h.HorarioBebidaId == horario))!;
    }

    public async Task<HorarioBebidas> Add(HorarioBebidas horario)
    {
        _context.HorarioBebidas.Add(horario);
        await _context.SaveChangesAsync();
        return horario;
    }

    public async Task<bool> Update(HorarioBebidas horario)
    {
        _context.Entry(horario).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(string id)
    {
        var IdCast = int.Parse(id);
        var horario = await _context.HorarioBebidas.FindAsync(IdCast);
        if (horario == null)
        {
            return false;
        }
        
        _context.HorarioBebidas.Remove(horario);
        return await _context.SaveChangesAsync() > 0;
    }
}
