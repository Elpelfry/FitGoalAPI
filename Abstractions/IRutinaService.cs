using Domain.DTO;

namespace Abstractions;

public interface IRutinaService
{
    Task<RutinasDto> Add(RutinasDto rutina);
    Task<RutinasDto> Get(int id);
    Task<bool> Update(RutinasDto rutina);
    Task<bool> Delete(int id);
    Task<List<RutinasDto>> GetListByUID(string UID);
}
