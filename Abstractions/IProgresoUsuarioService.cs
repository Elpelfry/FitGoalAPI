using Domain.DTO;

namespace Abstractions;

public interface IProgresoUsuarioService
{
    Task<ProgresoUsuariosDto> Add(ProgresoUsuariosDto progresoUsuarios);
    Task<ProgresoUsuariosDto> Get(int id);
    Task<bool> Update(ProgresoUsuariosDto progresoUsuario);
    Task<bool> Delete(int id);
    Task<bool> DeleteUserProgress(string id);
    Task<List<ProgresoUsuariosDto>> GetListByUID(string UID);
}
