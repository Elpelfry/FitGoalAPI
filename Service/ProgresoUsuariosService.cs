using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class ProgresoUsuariosService(FitGoalContext _context) : IProgresoUsuarioService
{
    public async Task<List<ProgresoUsuariosDto>> GetListByUID(string usuarioId)
    {
        return await _context.ProgresoUsuarios.
            Where(p => p.UsuarioId == usuarioId).Select(p => p.ToDto()).ToListAsync();
    }

    public async Task<ProgresoUsuariosDto> Get(int id)
    {
        return (await _context.ProgresoUsuarios.FindAsync(id))!.ToDto();
    }

    public async Task<ProgresoUsuariosDto> Add(ProgresoUsuariosDto progreso)
    {
        var model = progreso.ToModel();
        _context.ProgresoUsuarios.Add(model);
        await _context.SaveChangesAsync();
        return model.ToDto();
    }

    public async Task<bool> Update(ProgresoUsuariosDto progreso)
    {
        _context.Entry(progreso.ToModel()).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var progreso = await _context.ProgresoUsuarios.FindAsync(id);
        if (progreso == null)
        {
            return false;
        }
        _context.ProgresoUsuarios.Remove(progreso);
        return await _context.SaveChangesAsync() > 0;
    }
}