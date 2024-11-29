using Microsoft.AspNetCore.Mvc;
using FitGoalAPI.Authentication;
using Abstractions;
using Domain.DTO;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class EntrenamientosController(IEntrenamientoService _service) : ControllerBase
{
    // GET: api/Entrenamientos/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<EntrenamientosDto>>> GetList(string id)
    {
        return await _service.GetListByUID(id);
    }

    // GET: api/Entrenamientos/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<EntrenamientosDto>> Get(int id)
    {
        var entrenamiento = await _service.Get(id);

        if (entrenamiento == null)
            return NotFound();

        return entrenamiento;
    }

    // POST: api/Entrenamientos
    [HttpPost]
    public async Task<ActionResult<EntrenamientosDto>> Add(EntrenamientosDto entrenamiento)
    {
        var newEntrenamiento = await _service.Add(entrenamiento);
        return CreatedAtAction(nameof(Get), new { id = newEntrenamiento.EntrenamientoId }, newEntrenamiento);
    }

    // PUT: api/Entrenamientos/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EntrenamientosDto entrenamiento)
    {
        if (id != entrenamiento.EntrenamientoId)
        {
            return BadRequest();
        }
        await _service.Update(entrenamiento);
        return NoContent();
    }

    // DELETE: api/Entrenamientos/ID
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