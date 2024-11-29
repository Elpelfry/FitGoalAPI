using Domain.DTO;

namespace Abstractions;

public interface IUsuarioService
{
    Task<UsuariosDto> Add(UsuariosDto usuario);
    Task<UsuariosDto> Get(string id);
    Task<bool> Update(UsuariosDto usuario);
    Task<bool> Delete(string id);
}