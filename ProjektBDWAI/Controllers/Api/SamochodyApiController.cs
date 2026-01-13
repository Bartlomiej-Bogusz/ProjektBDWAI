using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Data;
using ProjektBDWAI.Models;

[Route("api/samochody")]
[ApiController]
public class SamochodyApiController : ControllerBase
{
    private readonly ProjektBDWAIContext _context;

    public SamochodyApiController(ProjektBDWAIContext context)
    {
        _context = context;
    }

    // READ ALL
    // GET: api/samochody
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Samochod>>> GetAll()
    {
        return await _context.Samochody.ToListAsync();
    }

    // READ ONE
    // GET: api/samochody/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Samochod>> Get(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        if (samochod == null)
            return NotFound();

        return samochod;
    }

    // CREATE
    // POST: api/samochody
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Samochod>> Create(Samochod samochod)
    {
        _context.Samochody.Add(samochod);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = samochod.Id }, samochod);
    }

    // UPDATE
    // PUT: api/samochody/5
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Samochod samochod)
    {
        if (id != samochod.Id)
            return BadRequest();

        _context.Entry(samochod).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE
    // DELETE: api/samochody/5
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        if (samochod == null)
            return NotFound();

        _context.Samochody.Remove(samochod);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}