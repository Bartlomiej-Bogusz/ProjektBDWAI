using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Data;
using System.Security.Claims;

[Authorize]
public class OpinieController : Controller
{
    private readonly ProjektBDWAIContext _context;

    public OpinieController(ProjektBDWAIContext context)
    {
        _context = context;
    }

    // LISTA + FORMULARZ
    public async Task<IActionResult> Index()
    {
        var opinie = await _context.Opinie
            .Include(o => o.User)
            .OrderByDescending(o => o.DataDodania)
            .ToListAsync();

        return View(opinie);
    }

    // DODAWANIE OPINII
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Dodaj(Opinia opinia)
    //{
    //    if (!ModelState.IsValid)
    //        return RedirectToAction(nameof(Index));

    //    opinia.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

    //    _context.Opinie.Add(opinia);
    //    await _context.SaveChangesAsync();

    //    return RedirectToAction(nameof(Index));
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Dodaj(string? Tresc, int Ocena)
    {
        if (Ocena < 1 || Ocena > 5)
        {
            TempData["Error"] = "Niepoprawna ocena.";
            return RedirectToAction(nameof(Index));
        }

        var opinia = new Opinia
        {
            Tresc = Tresc,
            Ocena = Ocena,
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            DataDodania = DateTime.Now
        };

        _context.Opinie.Add(opinia);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // USUWANIE – TYLKO ADMIN
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Usun(int id)
    {
        var opinia = await _context.Opinie.FindAsync(id);
        if (opinia == null)
            return NotFound();

        _context.Opinie.Remove(opinia);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}