using Domain.DTO;

namespace Abstractions;

public interface ITipService
{
    Task<TipsDto> Add(TipsDto tip);
    Task<TipsDto> Get(int id);
    Task<bool> Update(TipsDto tip);
    Task<bool> Delete(int id);
    Task<List<TipsDto>> GetAll();
}
