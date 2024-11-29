using Microsoft.AspNetCore.Mvc;
using FitGoalAPI.Authentication;
using Abstractions;
using Domain.DTO;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class RutinasController(IRutinaService _service) : ControllerBase
{
    // GET: api/Rutinas/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<RutinasDto>>> GetList(string id)
    {
        return await _service.GetListByUID(id);
    }

    // GET: api/Rutinas/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<RutinasDto>> Get(int id)
    {
        var ejercicio = await _service.Get(id);

        if (ejercicio == null)
            return NotFound();

        return ejercicio;
    }

    // POST: api/Rutinas
    [HttpPost]
    public async Task<ActionResult<RutinasDto>> Add(RutinasDto rutina)
    {
        var newrutina = await _service.Add(rutina);
        return CreatedAtAction(nameof(Get), new { id = newrutina.RutinaId }, newrutina);
    }

    // PUT: api/Rutinas/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RutinasDto rutina)
    {
        if (id != rutina.RutinaId)
        {
            return BadRequest();
        }
        await _service.Update(rutina);
        return NoContent();
    }

    // DELETE: api/Rutinas/ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}