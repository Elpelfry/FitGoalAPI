using FitGoalAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions;
using Shared.Models;

namespace FitGoalAPI.Service;

public class TipsService(Context _context) : IGenericService<Tips>
{
    public async Task<List<Tips>> GetAll()
    {
        return await _context.Tips.ToListAsync();
    }

    public async Task<Tips> Get(int id)
    {
        return (await _context.Tips.FindAsync(id))!;
    }

    public async Task<Tips> Add(Tips tip)
    {
        _context.Tips.Add(tip);
        await _context.SaveChangesAsync();
        return tip;
    }

    public async Task<bool> Update(Tips tip)
    {
        _context.Entry(tip).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var tip = await _context.Tips.FindAsync(id);
        if (tip == null)
        {
            return false;
        }
        _context.Tips.Remove(tip);
        return await _context.SaveChangesAsync() > 0;
    }
}