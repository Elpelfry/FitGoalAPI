using Microsoft.AspNetCore.Mvc;
using FitGoalAPI.Authentication;
using Abstractions;
using Domain.DTO;

namespace FitGoalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[ServiceFilter(typeof(ApiKeyAuthFilter))]
public class TipsController(ITipService _service) : ControllerBase
{
    // GET: api/Tips
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipsDto>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Tips/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TipsDto>> Get(int id)
    {
        var tip = await _service.Get(id);
        if (tip == null)
            return NotFound();

        return tip;
    }

    // POST: api/Tips
    [HttpPost]
    public async Task<ActionResult<TipsDto>> Add(TipsDto tip)
    {
        var newTip = await _service.Add(tip);
        return CreatedAtAction(nameof(Get), new { id = newTip.TipId }, newTip);
    }

    // PUT: api/Tips/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TipsDto tip)
    {
        if (id != tip.TipId)
            return BadRequest();

        await _service.Update(tip);
        return NoContent();
    }

    // DELETE: api/Tips/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}