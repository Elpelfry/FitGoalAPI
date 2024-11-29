using Microsoft.AspNetCore.Mvc;
using FitGoalAPI.Authentication;
using Abstractions;
using Domain.DTO;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class EjerciciosController(IEjercicioService _service) : ControllerBase
{
    // GET: api/Ejercicios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EjerciciosDto>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Ejercicios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EjerciciosDto>> Get(int id)
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
    public async Task<ActionResult<EjerciciosDto>> Add(EjerciciosDto ejercicio)
    {
        var newejercicio = await _service.Add(ejercicio);
        return CreatedAtAction(nameof(Get), new { id = newejercicio.EjercicioId }, newejercicio);
    }

    // PUT: api/Ejercicios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EjerciciosDto ejercicios)
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