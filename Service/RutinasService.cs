using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class RutinasService(FitGoalContext _context) : IRutinaService
{
    public async Task<List<RutinasDto>> GetListByUID(string usuarioId)
    {
        return await _context.Rutinas.
            Where(r => r.UsuarioId == usuarioId)
                .Include(d => d.RutinaEjercicios)
                    .Select(r => r.ToDto()).ToListAsync();
    }

    public async Task<RutinasDto> Get(int id)
    {
        return (await _context.Rutinas
            .Include(d => d.RutinaEjercicios)
                .FirstOrDefaultAsync(r => r.RutinaId == id))!.ToDto();
    }

    public async Task<RutinasDto> Add(RutinasDto rutina)
    {
        _context.Rutinas.Add(rutina.ToModel());
        await _context.SaveChangesAsync();
        return rutina;
    }

    public async Task<bool> Update(RutinasDto rutina)
    {
        _context.Entry(rutina.ToModel()).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var rutina = await _context.Rutinas.FindAsync(id);
        if (rutina == null)
        {
            return false;
        }
        await _context.RutinaEjercicios.
            Where(RE => RE.RutinaId == id).ExecuteDeleteAsync();
        _context.Rutinas.Remove(rutina);
        return await _context.SaveChangesAsync() > 0;
    }
}