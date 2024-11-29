using Microsoft.EntityFrameworkCore;
using Data.Context;
using Abstractions;
using Domain.DTO;
using Domain.Mappers;

namespace Service;

public class TipsService(FitGoalContext _context) : ITipService
{
    public async Task<List<TipsDto>> GetAll()
    {
        return await _context.Tips.Select(t => t.ToDto()).ToListAsync();
    }

    public async Task<TipsDto> Get(int id)
    {
        return (await _context.Tips.FindAsync(id))!.ToDto();
    }

    public async Task<TipsDto> Add(TipsDto tip)
    {
        _context.Tips.Add(tip.ToModel());
        await _context.SaveChangesAsync();
        return tip;
    }

    public async Task<bool> Update(TipsDto tip)
    {
        _context.Entry(tip.ToModel()).State = EntityState.Modified;
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