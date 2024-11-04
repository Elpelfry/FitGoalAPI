using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class EjerciciosService(Context _context) : IGenericService<Ejercicios>
{
    public async Task<List<Ejercicios>> GetAll()
    {
        return await _context.Ejercicios.ToListAsync();
    }

    public async Task<Ejercicios> Get(int id)
    {
        return (await _context.Ejercicios.FindAsync(id))!;
    }
    public async Task<Ejercicios> Add(Ejercicios ejercicio)
    {
        _context.Ejercicios.Add(ejercicio);
        await _context.SaveChangesAsync();
        return ejercicio;
    }

    public async Task<bool> Update(Ejercicios ejercicio)
    {
        _context.Entry(ejercicio).State = EntityState.Modified;
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