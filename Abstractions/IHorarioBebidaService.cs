using Domain.DTO;

namespace Abstractions;

public interface IHorarioBebidaService
{
    Task<HorarioBebidasDto> Add(HorarioBebidasDto horarioBebida);
    Task<HorarioBebidasDto> Get(int id);
    Task<bool> Update(HorarioBebidasDto horarioBebida);
    Task<bool> Delete(int id);
    Task<List<HorarioBebidasDto>> GetListByUID(string UID);
}
