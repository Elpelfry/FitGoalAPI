using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class HorarioBebidasService(FitGoalContext _context) : IHorarioBebidaService
{
    public async Task<List<HorarioBebidasDto>> GetListByUID(string usuarioId)
    {
        return await _context.HorarioBebidas.
            Where(h => h.UsuarioId == usuarioId).Select(h => h.ToDto()).ToListAsync();
    }

    public async Task<HorarioBebidasDto> Get(int id)
    {
        return (await _context.HorarioBebidas.FindAsync(id))!.ToDto();
    }

    public async Task<HorarioBebidasDto> Add(HorarioBebidasDto horario)
    {
        _context.HorarioBebidas.Add(horario.ToModel());
        await _context.SaveChangesAsync();
        return horario;
    }

    public async Task<bool> Update(HorarioBebidasDto horario)
    {
        _context.Entry(horario.ToModel()).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var horario = await _context.HorarioBebidas.FindAsync(id);
        if (horario == null)
        {
            return false;
        }

        _context.HorarioBebidas.Remove(horario);
        return await _context.SaveChangesAsync() > 0;
    }
}