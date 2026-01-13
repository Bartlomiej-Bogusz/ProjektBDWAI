using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Data;
using ProjektBDWAI.Models;
using System.Security.Claims;

[Authorize]
public class RezerwacjeController : Controller
{
    private readonly ProjektBDWAIContext _context;

    public RezerwacjeController(ProjektBDWAIContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> MojeRezerwacje()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var rezerwacje = await _context.Rezerwacje
            .Include(r => r.Samochod)
            .Where(r => r.UserId == userId)
            .ToListAsync();

        return View(rezerwacje);
    }

    [HttpPost]
    public async Task<IActionResult> Zaplac(int id)
    {
        var rezerwacja = await _context.Rezerwacje
            .Include(r => r.Samochod)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (rezerwacja == null) return NotFound();

        // utwórz płatność na podstawie ceny za dzień * dni rezerwacji
        var kwota = rezerwacja.Samochod.CenaZaDzien * rezerwacja.Dni;

        var platnosc = new Platnosc
        {
            Kwota = kwota,
            DataPlatnosci = DateTime.Now,
            RezerwacjaId = rezerwacja.Id
        };

        rezerwacja.Status = StatusRezerwacji.Zaplacona;

        _context.Platnosci.Add(platnosc);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(MojeRezerwacje));
    }

    [HttpPost]
    public async Task<IActionResult> Anuluj(int id)
    {
        var rezerwacja = await _context.Rezerwacje
            .Include(r => r.Samochod)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (rezerwacja == null) return NotFound();

        rezerwacja.Status = StatusRezerwacji.Anulowana;
        rezerwacja.Samochod.Dostepny = true;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(MojeRezerwacje));
    }
}