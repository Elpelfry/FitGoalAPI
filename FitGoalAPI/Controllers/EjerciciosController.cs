using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Abstractions;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EjerciciosController(IGenericService<Ejercicios> _service) : ControllerBase
{
    // GET: api/Ejercicios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ejercicios>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Ejercicios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ejercicios>> Get(int id)
    {
        var ejercicio = await _service.Get(id);

        if (ejercicio == null)
        {
            return NotFound();
        }

        return ejercicio;
    }

    // POST: api/Ejercicios
    [HttpPost]
    public async Task<ActionResult<Ejercicios>> Add(Ejercicios ejercicio)
    {
        var newejercicio = await _service.Add(ejercicio);
        return CreatedAtAction(nameof(Get), new { id = newejercicio.EjercicioId }, newejercicio);
    }

    // PUT: api/Ejercicios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Ejercicios ejercicios)
    {
        if (id != ejercicios.EjercicioId)
        {
            return BadRequest();
        }
        await _service.Update(ejercicios);
        return NoContent();
    }

    // DELETE: api/Ejercicios/5
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