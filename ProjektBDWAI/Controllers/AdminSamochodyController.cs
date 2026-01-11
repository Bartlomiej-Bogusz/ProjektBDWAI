using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBDWAI.Data;
using ProjektBDWAI.Models;

[Authorize(Roles = "Admin")]
public class AdminSamochodyController : Controller
{
    private readonly ProjektBDWAIContext _context;

    public AdminSamochodyController(ProjektBDWAIContext context)
    {
        _context = context;
    }

    // READ
    public async Task<IActionResult> Index()
    {
        return View(await _context.Samochody.ToListAsync());
    }

    // CREATE
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Samochod samochod)
    {
        if (!ModelState.IsValid)
            return View(samochod);

        _context.Samochody.Add(samochod);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // UPDATE
    public async Task<IActionResult> Edit(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        if (samochod == null) return NotFound();
        return View(samochod);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Samochod samochod)
    {
        if (id != samochod.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(samochod);

        _context.Update(samochod);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // DELETE
    public async Task<IActionResult> Delete(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        if (samochod == null) return NotFound();
        return View(samochod);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        _context.Samochody.Remove(samochod);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}