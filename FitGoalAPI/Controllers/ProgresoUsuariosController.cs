using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Abstractions;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgresoUsuariosController(IUserService<ProgresoUsuarios> _service) : ControllerBase
{
    // GET: api/ProgresoUsuarios/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<ProgresoUsuarios>>> GetList(string id)
    {
        return await _service.GetListByUID(id);
    }

    // GET: api/ProgresoUsuarios/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgresoUsuarios>> Get(string id)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        var progreso = await _service.Get(id);

        if (progreso == null)
            return NotFound();

        return progreso;
    }

    // POST: api/ProgresoUsuarios
    [HttpPost]
    public async Task<ActionResult<ProgresoUsuarios>> Add(ProgresoUsuarios progreso)
    {
        var newProgreso = await _service.Add(progreso);
        return CreatedAtAction(nameof(Get), new { id = newProgreso.ProgresoId }, newProgreso);
    }

    // PUT: api/ProgresoUsuarios/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, ProgresoUsuarios progreso)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        if (result != progreso.ProgresoId)
        {
            return BadRequest();
        }
        await _service.Update(progreso);
        return NoContent();
    }

    // DELETE: api/ProgresoUsuarios/ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        var results = await _service.Delete(id);
        if (!results)
        {
            return NotFound();
        }
        return NoContent();
    }
}