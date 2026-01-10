using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Data;
using ProjektBDWAI.Models;
using System.Security.Claims;

[Authorize]
public class SamochodyController : Controller
{
    private readonly ProjektBDWAIContext _context;

    public SamochodyController(ProjektBDWAIContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var samochody = await _context.Samochody
            .Where(s => s.Dostepny)
            .ToListAsync();

        return View(samochody);
    }

    [HttpPost]
    public async Task<IActionResult> Zarezerwuj(int samochodId)
    {
        var samochod = await _context.Samochody.FindAsync(samochodId);
        if (samochod == null || !samochod.Dostepny)
            return NotFound();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var rezerwacja = new Rezerwacja
        {
            SamochodId = samochodId,
            UserId = userId,
            Status = StatusRezerwacji.Oczekujaca
        };

        samochod.Dostepny = false;

        _context.Rezerwacje.Add(rezerwacja);
        await _context.SaveChangesAsync();

        return RedirectToAction("MojeRezerwacje", "Rezerwacje");
    }
}