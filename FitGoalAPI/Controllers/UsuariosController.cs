using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Abstractions;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController(IUserService<Usuarios> _service) : ControllerBase
{
    // GET: api/Usuarios/List/UID
    [HttpGet("List/{UID}")]
    public async Task<ActionResult<IEnumerable<Usuarios>>> GetList(string UID)
    {
        return await _service.GetListByUID(UID);
    }

    // GET: api/Usuarios/UID
    [HttpGet("{UID}")]
    public async Task<ActionResult<Usuarios>> Get(string UID)
    {
        var usuario = await _service.Get(UID);
        if (usuario == null)
            return NotFound();

        return usuario;
    }

    // POST: api/Usuarios
    [HttpPost]
    public async Task<ActionResult<Usuarios>> Add(Usuarios usuario)
    {
        var newUsuario = await _service.Add(usuario);
        return CreatedAtAction(nameof(Get), new { UID = newUsuario.UsuarioId }, newUsuario);
    }

    // PUT: api/Usuarios/UID
    [HttpPut("{UID}")]
    public async Task<IActionResult> Update(string UID, Usuarios usuario)
    {
        if (UID != usuario.UsuarioId)
            return BadRequest();

        await _service.Update(usuario);
        return NoContent();
    }

    // DELETE: api/Usuarios/UID
    [HttpDelete("{UID}")]
    public async Task<IActionResult> Delete(string UID)
    {
        var result = await _service.Delete(UID);
        if (!result)
            return NotFound();

        return NoContent();
    }
}