using Microsoft.AspNetCore.Mvc;
using FitGoalAPI.Authentication;
using Abstractions;
using Domain.DTO;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class HorarioBebidasController(IHorarioBebidaService _service) : ControllerBase
{
    // GET: api/HorarioBebidas/List/ID
    [HttpGet("List/{id}")]
    public async Task<ActionResult<IEnumerable<HorarioBebidasDto>>> GetList(string id)
    {
        var horarios = await _service.GetListByUID(id);
        return Ok(horarios);
    }

    // GET: api/HorarioBebidas/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<HorarioBebidasDto>> Get(int id)
    {
        var horario = await _service.Get(id);

        if (horario == null)
            return NotFound();

        return horario;
    }

    // POST: api/HorarioBebidas
    [HttpPost]
    public async Task<ActionResult<HorarioBebidasDto>> Add(HorarioBebidasDto horario)
    {
        var newHorario = await _service.Add(horario);
        return CreatedAtAction(nameof(Get), new { id = newHorario.HorarioBebidaId }, newHorario);
    }

    // PUT: api/HorarioBebidas/ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, HorarioBebidasDto horario)
    {
        if (id != horario.HorarioBebidaId)
        {
            return BadRequest();
        }

        await _service.Update(horario);
        return NoContent();
    }

    // DELETE: api/HorarioBebidas/ID
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