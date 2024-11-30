using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class EjerciciosService(FitGoalContext _context) : IEjercicioService
{
    public async Task<List<EjerciciosDto>> GetAll()
    {
        return await _context.Ejercicios.Select(e => e.ToDto()).ToListAsync();
    }

    public async Task<EjerciciosDto> Get(int id)
    {
        return (await _context.Ejercicios.FindAsync(id))!.ToDto();
    }
    public async Task<EjerciciosDto> Add(EjerciciosDto ejercicio)
    {
        var model = ejercicio.ToModel();
        _context.Ejercicios.Add(model);
        await _context.SaveChangesAsync();
        return model.ToDto();
    }

    public async Task<bool> Update(EjerciciosDto ejercicio)
    {
        _context.Entry(ejercicio.ToModel()).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Delete(int id)
    {
        var ejercicio = await _context.Ejercicios.FindAsync(id);
        if (ejercicio == null)
        {
            return false;
        }
        _context.Ejercicios.Remove(ejercicio);
        return await _context.SaveChangesAsync() > 0;
    }
}