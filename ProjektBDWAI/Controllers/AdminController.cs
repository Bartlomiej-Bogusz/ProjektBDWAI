using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Data;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ProjektBDWAIContext _context;

    public AdminController(ProjektBDWAIContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new AdminDashboardViewModel
        {
            Uzytkownicy = await _context.Users.ToListAsync(),

            Samochody = await _context.Samochody.ToListAsync(),

            Rezerwacje = await _context.Rezerwacje
                .Include(r => r.Samochod)
                .ToListAsync(),

            Platnosci = await _context.Platnosci
                .Include(p => p.Rezerwacja)
                .ThenInclude(r => r.Samochod)
                .ToListAsync()
        };

        return View(vm);
    }
}