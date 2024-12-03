using Microsoft.AspNetCore.Mvc;
using FitGoalAPI.Authentication;
using Abstractions;
using Domain.DTO;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class ProgresoUsuariosController(IProgresoUsuarioService _service) : ControllerBase
{
    // GET: api/ProgresoUsuarios/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<ProgresoUsuariosDto>>> GetList(string id)
    {
        return await _service.GetListByUID(id);
    }

    // GET: api/ProgresoUsuarios/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgresoUsuariosDto>> Get(int id)
    {
        var progreso = await _service.Get(id);

        if (progreso == null)
            return NotFound();

        return progreso;
    }

    // POST: api/ProgresoUsuarios
    [HttpPost]
    public async Task<ActionResult<ProgresoUsuariosDto>> Add(ProgresoUsuariosDto progreso)
    {
        var newProgreso = await _service.Add(progreso);
        return CreatedAtAction(nameof(Get), new { id = newProgreso.ProgresoId }, newProgreso);
    }

    // PUT: api/ProgresoUsuarios/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProgresoUsuariosDto progreso)
    {
        if (id != progreso.ProgresoId)
        {
            return BadRequest();
        }
        await _service.Update(progreso);
        return NoContent();
    }

    // DELETE: api/ProgresoUsuarios/ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var results = await _service.Delete(id);
        if (!results)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    // DELETE: api/ProgresoUsuarios/User/ID
    [HttpDelete("User/{id}")]
    public async Task<IActionResult> DeleteUserProgress(string id)
    {
        var results = await _service.DeleteUserProgress(id);
        if (!results)
        {
            return NotFound();
        }
        return NoContent();
    }
}