using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Abstractions;
using FitGoalAPI.Authentication;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class EntrenamientosController(IUserService<Entrenamientos> _service) : ControllerBase
{
    // GET: api/Entrenamientos/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<Entrenamientos>>> GetList(string id)
    {
        return await _service.GetListByUID(id);
    }

    // GET: api/Entrenamientos/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Entrenamientos>> Get(string id)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        var entrenamiento = await _service.Get(id);

        if (entrenamiento == null)
            return NotFound();

        return entrenamiento;
    }

    // POST: api/Entrenamientos
    [HttpPost]
    public async Task<ActionResult<Entrenamientos>> Add(Entrenamientos entrenamiento)
    {
        var newEntrenamiento = await _service.Add(entrenamiento);
        return CreatedAtAction(nameof(Get), new { id = newEntrenamiento.EntrenamientoId }, newEntrenamiento);
    }

    // PUT: api/Entrenamientos/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Entrenamientos entrenamiento)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        if (result != entrenamiento.EntrenamientoId)
        {
            return BadRequest();
        }
        await _service.Update(entrenamiento);
        return NoContent();
    }

    // DELETE: api/Entrenamientos/ID
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