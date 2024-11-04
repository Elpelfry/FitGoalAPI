using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Abstractions;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RutinasController(IUserService<Rutinas> _service) : ControllerBase
{
    // GET: api/Rutinas/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<Rutinas>>> GetList(string id)
    {
        return await _service.GetListByUID(id);
    }

    // GET: api/Rutinas/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Rutinas>> Get(string id)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        var ejercicio = await _service.Get(id);

        if (ejercicio == null)
            return NotFound();

        return ejercicio;
    }

    // POST: api/Rutinas
    [HttpPost]
    public async Task<ActionResult<Rutinas>> Add(Rutinas rutina)
    {
        var newrutina = await _service.Add(rutina);
        return CreatedAtAction(nameof(Get), new { id = newrutina.RutinaId }, newrutina);
    }

    // PUT: api/Rutinas/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Rutinas rutina)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        if (result != rutina.RutinaId)
        {
            return BadRequest();
        }
        await _service.Update(rutina);
        return NoContent();
    }

    // DELETE: api/Rutinas/ID
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