using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class EntrenamientosService(FitGoalContext _context) : IEntrenamientoService
{
    public async Task<List<EntrenamientosDto>> GetListByUID(string usuarioId)
    {
        return await _context.Entrenamientos.
            Where(e => e.UsuarioId == usuarioId).Select(e => e.ToDto()).ToListAsync();
    }

    public async Task<EntrenamientosDto> Get(int id)
    {
        return (await _context.Entrenamientos.FindAsync(id))!.ToDto();
    }

    public async Task<EntrenamientosDto> Add(EntrenamientosDto entrenamiento)
    {
        _context.Entrenamientos.Add(entrenamiento.ToModel());
        await _context.SaveChangesAsync();
        return entrenamiento;
    }

    public async Task<bool> Update(EntrenamientosDto entrenamiento)
    {
        _context.Entry(entrenamiento.ToModel()).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var entrenamiento = await _context.Entrenamientos.FindAsync(id);
        if (entrenamiento == null)
        {
            return false;
        }
        _context.Entrenamientos.Remove(entrenamiento);
        return await _context.SaveChangesAsync() > 0;
    }
}