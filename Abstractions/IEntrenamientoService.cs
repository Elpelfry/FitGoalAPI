using Domain.DTO;

namespace Abstractions;

public interface IEntrenamientoService
{
    Task<EntrenamientosDto> Add(EntrenamientosDto entrenamiento);
    Task<EntrenamientosDto> Get(int id);
    Task<bool> Update(EntrenamientosDto entrenamiento);
    Task<bool> Delete(int id);
    Task<List<EntrenamientosDto>> GetListByUID(string UID);
}
