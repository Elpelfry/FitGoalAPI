using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Abstractions;
using FitGoalAPI.Authentication;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class HorarioBebidasController(IUserService<HorarioBebidas> _service) : ControllerBase
{
    // GET: api/HorarioBebidas/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<HorarioBebidas>>> GetList(string id)
    {
        var horarios = await _service.GetListByUID(id);
        return Ok(horarios);
    }

    // GET: api/HorarioBebidas/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<HorarioBebidas>> Get(string id)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        var horario = await _service.Get(id);

        if (horario == null)
            return NotFound();

        return horario;
    }

    // POST: api/HorarioBebidas
    [HttpPost]
    public async Task<ActionResult<HorarioBebidas>> Add(HorarioBebidas horario)
    {
        var newHorario = await _service.Add(horario);
        return CreatedAtAction(nameof(Get), new { id = newHorario.HorarioBebidaId }, newHorario);
    }

    // PUT: api/HorarioBebidas/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, HorarioBebidas horario)
    {
        if (!int.TryParse(id, out int result))
            return BadRequest("El ID proporcionado no es un número entero válido.");

        if (result != horario.HorarioBebidaId)
        {
            return BadRequest();
        }

        await _service.Update(horario);
        return NoContent();
    }

    // DELETE: api/HorarioBebidas/ID
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

